using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobControl : MonoBehaviour {

    public GameObject explode; //宣告一個名為explo的物件
    public GameObject healthBarCtrl;
    private GameObject mobExplClone;
    private GameObject playerExplClone;
    private float time; //宣告浮點數，名稱time
    private float speedPirod ;
    private float startSpeed;
    private int hp;
    private int max_hp;
	// Use this for initialization
	void Start () {
        max_hp = hp = 5;
        speedPirod = 1;
        startSpeed = 0.02f;
	}

	// Update is called once per frame
	void Update () {
        time += Time.deltaTime; //時間增加

        gameObject.transform.position += new Vector3(0, -(startSpeed+(time/speedPirod)/100), 0);
	}

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("[Mob] =========== is " + collider.tag);

        if (collider.tag != "Bullets" && collider.tag != "Player")
            return;

        if (collider.tag == "Bullets") {
            hp--;

            healthBarCtrl.GetComponent<healthBarCtrl>().changeHealBar(max_hp, newHp: hp);

            Destroy(collider.gameObject); // 刪掉子彈

            if (hp > 0) return;

            // 怪物死亡，加分數
            socreBoardControl.Instance.AddScore();
        }

        Vector3 pos = gameObject.transform.position;
        mobExplClone = Instantiate(explode,gameObject.transform.position,gameObject.transform.rotation); //在外星人的位置產生爆炸
        Destroy(gameObject);
    }
}
