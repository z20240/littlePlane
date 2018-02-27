using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class bulletControl : MonoBehaviour {

    private GameObject master;
    private string masterName;// 應該改成字串
    float bullet_speed;
    private BulletBehaviorCtrl bulletBhvCtrl;
    private Vector3 direct;
    GameObject bulletBhvMng;
    gamePlayManager gpMng;
    public string MasterName { get { return masterName; } set { masterName = value; } }

    void Start () {
        GameObject gameCfg = GameObject.Find("gamePlayManager");
        gpMng = gameCfg.GetComponent<gamePlayManager>();
        JsonData conf = gpMng.getGameConfig();

        if (master == null) {
            Destroy(gameObject);
            return;
        }

        if (master.tag == "Player") {
            bullet_speed = (float)conf["player"]["bullet_speed"];
        } else{
            bullet_speed = (float)((double)conf["mob_bullet_speed"] + gpMng.getStage()*(double)conf["mob_bullet_offset"]);
        }

        Debug.Log("bulletSpeed" + bullet_speed);

        bulletBhvMng = GameObject.Find("BulletBehaviorManager");
        bulletBhvCtrl = bulletBhvMng.GetComponent<BulletBehaviorCtrl>();

        direct = gameObject.transform.position - master.transform.position;
        // Debug.Log("Mater" + master.transform.position + " " + gameObject.name + gameObject.transform.position );
    }

    // Update is called once per frame
    void Update () {
        // Debug.Log(gameObject.name + "  direct" + direct + "Normalized " + direct.normalized);
        bulletBhvCtrl.BulletMove(direct, gameObject, bullet_speed);
    }

    public GameObject getMaster() { return master; }
    public void setMaster(GameObject go) { master = go; }


}
