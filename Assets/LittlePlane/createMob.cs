using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class createMob : MonoBehaviour {

    public GameObject mob1;  // 宣告物件，名稱mob_mormal
    public GameObject mob2; // 宣告物件，名稱mob_mid
    public GameObject mob3; // 宣告物件，名稱mob_hard
    public GameObject boss1; // 宣告物件，名稱boss_1
    public GameObject boss2; // 宣告物件，名稱boss_2
    public GameObject boss3; // 宣告物件，名稱boss_3
    private float mob_create_freq;
    private float boss_create_freq;

    static class MobTimeCount {
        static public float boss;
        static public float mob1;
        static public float mob2;
        static public float mob3;
    };
    private float boss_appear_time;
    private float time; //宣告浮點數，名稱time
    GameObject[] bossList;
    gamePlayManager gamePlayMng;


    // Use this for initialization
    void Start () {
        GameObject gameCfg = GameObject.Find("gamePlayManager");
        gamePlayMng = gameCfg.GetComponent<gamePlayManager>();
        JsonData conf = gamePlayMng.getGameConfig();

        mob_create_freq = (float)conf["mob_create_freq"];
        boss_create_freq = (float)conf["boss_create_freq"];

        bossList = new GameObject[] {boss1, boss2, boss3};
    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime; //時間增加

        int now = (int)(System.DateTime.Now.AddHours ( -8 ) - new System.DateTime( 1970, 1, 1, 0, 0, 0 ) ).TotalSeconds;
        if (now >= gamePlayMng.BossDeadAwakeTime && !gamePlayMng.BossFlag) {
            gamePlayMng.BossFlag = true;
            Vector3 pos = new Vector3 (0, 3.1f, 0); //宣告位置pos，Random.Range(-2.5f,2.5f)代表X是2.5到-2.5之間隨機
            Instantiate(bossList[Random.Range(0, 3)], pos, transform.rotation); //產生敵人
        }

        // Debug.Log("time" + time + " mob1:" + MobTimeCount.mob1 + " mob2:" + MobTimeCount.mob2 + " mob3:" + MobTimeCount.mob3 + " gamePlayMng.BossFlag:" + gamePlayMng.BossFlag);
        if (time >= MobTimeCount.mob1 && !gamePlayMng.BossFlag) { //如果時間大於mob_create_freq(秒)
            Vector3 pos = new Vector3 (Random.Range(-3.6f, 3.6f), 3.1f, 0); //宣告位置pos，Random.Range(-2.5f,2.5f)代表X是2.5到-2.5之間隨機
            Instantiate(mob1, pos, transform.rotation); //產生敵人
            MobTimeCount.mob1 += mob_create_freq;
        }

        if (time >= MobTimeCount.mob2-1 && !gamePlayMng.BossFlag) { //如果時間大於mob_create_freq(秒)
            Vector3 pos = new Vector3 (Random.Range(-3.6f, 3.6f), 3.1f, 0); //宣告位置pos，Random.Range(-2.5f,2.5f)代表X是2.5到-2.5之間隨機
            Instantiate(mob2, pos, transform.rotation); //產生敵人
            MobTimeCount.mob2 += mob_create_freq;
        }

        if (time >= MobTimeCount.mob3-2 && !gamePlayMng.BossFlag) { //如果時間大於mob_create_freq(秒)
            Vector3 pos = new Vector3 (Random.Range(-3.6f, 3.6f), 3.1f, 0); //宣告位置pos，Random.Range(-2.5f,2.5f)代表X是2.5到-2.5之間隨機
            Instantiate(mob3, pos, transform.rotation); //產生敵人
            MobTimeCount.mob3 += mob_create_freq;
        }
    }
}