using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeControl : MonoBehaviour {

    // Use this for initialization

    public GameObject bullet;
    public GameObject healthBarCtrl;
    public GameObject explode; //宣告一個名為explo的物件
    private GameObject playerExplClone;
    private float fireRate;
    private float nextFire;
    private int hp;
    private int max_hp;
    void Start () {
        fireRate = 0.15f;
        nextFire = 0.0f;
        max_hp = hp = 3;
    }

    // Update is called once per frame
    void Update () {
        float plane_speed = 0.1f;
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
        // if (Input.GetKey(KeyCode.Space)) {
            if (Time.time > nextFire) {
                nextFire += fireRate;
                Vector3 pos_bullet_create = gameObject.transform.position + new Vector3(0, 0.6f, 0);
                Instantiate(bullet, pos_bullet_create, gameObject.transform.rotation); // 如果是 UI 的話就要另外設定
            }
        // }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("[Player] =========== is " + collider.tag);
        if (collider.tag == "Bullets") {
            Destroy(collider.gameObject); // 刪掉子彈
        }

        hp--;

        healthBarCtrl.GetComponent<healthBarCtrl>().changeHealBar(max_hp, newHp: hp);

        if (hp > 0) return;

        Vector3 pos = gameObject.transform.position;
        playerExplClone = Instantiate(explode,gameObject.transform.position,gameObject.transform.rotation); //在玩家的位置產生爆炸
        Destroy(gameObject);
    }
}
