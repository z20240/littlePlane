using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMob : MonoBehaviour {

    public GameObject mob1; //宣告物件，名稱Emeny

    private int offset;
    public float mob_speed;
    private GameObject mob1_clone;
    private float create_mob1_rng;
    private float speedPirod;
    private float time; //宣告浮點數，名稱time

    // Use this for initialization
    void Start () {
        speedPirod = 2;
        create_mob1_rng = 2f;
        offset = 100;
        mob_speed = 2f / offset;
    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime; //時間增加
        mob_speed = mob_speed + (time / speedPirod) / offset;
        if (time > create_mob1_rng) { //如果時間大於0.5(秒)
            Vector3 pos = new Vector3 (Random.Range(-3.6f, 3.6f), 3.1f, 0); //宣告位置pos，Random.Range(-2.5f,2.5f)代表X是2.5到-2.5之間隨機
            Instantiate(mob1, pos, transform.rotation); //產生敵人
            // mob1_clone.transform.position = gameObject.transform.position + pos;
            // mob1_clone.transform.SetParent(GameObject.Find("Canvas").transform, false);
            time = 0f; //時間歸零
        }
    }
}