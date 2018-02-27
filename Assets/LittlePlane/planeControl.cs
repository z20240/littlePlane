using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
public class planeControl : MonoBehaviour {

    // Use this for initialization

    public GameObject bullet;
    public GameObject healthBarCtrl;
    public GameObject explode; //宣告一個名為explo的物件
    private GameObject playerExplClone;

    private BulletBehaviorCtrl bulletBhvCtrl;
    private GameObject bulletBhvMng;
    private float fireRate;
    private float nextFire;
    private int hp;
    private int max_hp;
    private float plane_speed;

    gamePlayManager gpMng;
    void Start () {
        nextFire = 0.0f;

        GameObject gameCfg = GameObject.Find("gamePlayManager");
        gpMng = gameCfg.GetComponent<gamePlayManager>();
        JsonData conf = gpMng.getGameConfig();

        fireRate = (float)((double)conf["player"]["fireRate"]);
        max_hp = hp = (int)conf["player"]["hp"];
        plane_speed = (float)((double)conf["player"]["speed"]);

        bulletBhvMng = GameObject.Find("BulletBehaviorManager");
        bulletBhvCtrl = bulletBhvMng.GetComponent<BulletBehaviorCtrl>();
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.RightArrow)) {
            gameObject.transform.position += new Vector3(plane_speed,0,0);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            gameObject.transform.position += new Vector3(-plane_speed,0,0);
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            gameObject.transform.position += new Vector3(0,plane_speed,0);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            gameObject.transform.position += new Vector3(0,-plane_speed,0);
        }

        if (Time.time > nextFire) {
            nextFire += fireRate;
            Vector3 pos_bullet_create = gameObject.transform.position + new Vector3(0, 0.6f, 0);
            bulletBhvCtrl.ShotBehaviorNormal(gameObject, bullet, pos_bullet_create);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider == null) return;
        // Debug.Log("[Player] =========== is " + collider.tag);

        // 如果是我方子彈，就不理他
        if (collider.tag == "Bullets") {
            // 如果子彈的主人跟我同陣營，這顆子彈不對我有用
            if (collider.GetComponent<bulletControl>().MasterName == gameObject.tag)
                return ;
        }

        if (collider.tag == "Bullets") {
            Destroy(collider.gameObject); // 刪掉子彈
        }

        hp--;

        healthBarCtrl.GetComponent<healthBarCtrl>().changeHealBar(max_hp, newHp: hp);

        if (hp > 0) return;

        Vector3 pos = gameObject.transform.position;
        playerExplClone = Instantiate(explode,gameObject.transform.position,gameObject.transform.rotation); //在玩家的位置產生爆炸
        Destroy(gameObject); // 玩家死亡

        gpMng.gameOverTitle.SetActive(true);
        gpMng.PlayerDead = true;
    }
}
