using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class mobControl : MonoBehaviour {

    public GameObject explode; //宣告一個名為explo的物件
    public GameObject healthBarCtrl;
    private GameObject mobExplClone;
    private GameObject playerExplClone;
    private float speed;
    private float time;
    private int hp;
    private int max_hp;

    gamePlayManager gamePlayMng;
    JsonData conf;


	void Start () {
        GameObject gameCfg = GameObject.Find("gamePlayManager");
        gamePlayMng = gameCfg.GetComponent<gamePlayManager>();
        conf = gamePlayMng.getGameConfig();

        if (gameObject.transform.name.Contains("mob_normal")) {
            max_hp = hp = (int)conf["mob"]["mob_normal"]["hp"] + gamePlayMng.getStage();
            speed = (float)((double)conf["mob"]["mob_normal"]["speed"] + gamePlayMng.getStage()*(double)conf["mob_speed_offset"]);
        }
        if (gameObject.transform.name.Contains("mob_mid")) {
            max_hp = hp = (int)conf["mob"]["mob_mid"]["hp"] + gamePlayMng.getStage();
            speed = (float)((double)conf["mob"]["mob_mid"]["speed"] + gamePlayMng.getStage()*(double)conf["mob_speed_offset"]);
        }
        if (gameObject.transform.name.Contains("mob_hard")) {
            max_hp = hp = (int)conf["mob"]["mob_hard"]["hp"] + gamePlayMng.getStage();
            speed = (float)((double)conf["mob"]["mob_hard"]["speed"] + gamePlayMng.getStage()*(double)conf["mob_speed_offset"]);
        }
        if (gameObject.transform.name.Contains("mob_boss")) {
            Debug.Log("生出Boss:" + gameObject.name);
            max_hp = hp = (int)conf["mob"]["mob_boss"] + gamePlayMng.getStage();
        }

	}

	// Update is called once per frame
	void Update () {
        Debug.Log("speed:" + speed + " down:" +  Vector2.down);

        if (!gameObject.transform.name.Contains("mob_boss"))
            gameObject.transform.position += (Vector3.down * speed);


        if (gameObject.transform.name.Contains("mob_boss") && gameObject.transform.position.y > 1.69)
            gameObject.transform.position += (Vector3.down * (float)((double)conf["mob_speed_offset"]));

        if (gameObject.transform.name.Contains("mob_boss") && gameObject.transform.position.y <= 1.69) {
            time += Time.deltaTime;
            float hudu = ((float)(time * 36 / 360) * Mathf.PI); // 每秒移動 36 度
            float xx = 0 + ( 2.5f ) * Mathf.Sin (hudu); // r = 2.5

            gameObject.transform.position = new Vector3(xx, gameObject.transform.position.y, 0);
        }
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider == null) return;

        if (collider.tag != "Bullets" && collider.tag != "Player")
            return;

        if (collider.tag == "Bullets") {
            // 如果子彈的主人掛了，這顆子彈沒有用處
            if (!collider.GetComponent<bulletControl>().getMaster())
                return ;
            // 如果子彈的主人跟我同陣營，這顆子彈不對我有用
            if (collider.GetComponent<bulletControl>().getMaster().tag == gameObject.tag)
                return;
        }

        if (collider.tag == "Bullets") {
            hp--;

            healthBarCtrl.GetComponent<healthBarCtrl>().changeHealBar(max_hp, newHp: hp);

            Destroy(collider.gameObject); // 刪掉子彈

            if (hp > 0) return;

            // 怪物死亡，加分數
            socreBoardControl.Instance.AddScore();
            // 打死 Boss
            if (gameObject.name.Contains("mob_boss")) {
                gamePlayMng.BossFlag = false;
                int now = (int)(System.DateTime.Now.AddHours ( -8 ) - new System.DateTime( 1970, 1, 1, 0, 0, 0 ) ).TotalSeconds;
                gamePlayMng.BossDeadAwakeTime = now + (int)conf["boss_create_freq"];
                gamePlayMng.addStage();
            }
        }

        Vector3 pos = gameObject.transform.position;
        mobExplClone = Instantiate(explode,gameObject.transform.position,gameObject.transform.rotation); //在外星人的位置產生爆炸
        Destroy(gameObject);
    }
}
