using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class mobFireControl : MonoBehaviour {
    public GameObject bullet;
    private BulletBehaviorCtrl bulletBhvCtrl;
    private GameObject bulletBhvMng;

    private float fireRate = 0.01f;
    private float nextFire = 0.0f;
    private int curAngle = 0;
    private int nextRange = 30;

    gamePlayManager gamePlayMng;
    JsonData conf;

	void Start () {
        bulletBhvMng = GameObject.Find("BulletBehaviorManager");
        bulletBhvCtrl = bulletBhvMng.GetComponent<BulletBehaviorCtrl>();

        GameObject gameCfg = GameObject.Find("gamePlayManager");
        gamePlayMng = gameCfg.GetComponent<gamePlayManager>();
        conf = gamePlayMng.getGameConfig();

        if (gameObject.transform.name.Contains("mob_mid")) {
            fireRate = (float)((double)conf["mob"]["mob_mid"]["fireRate"]);
        }
        if (gameObject.transform.name.Contains("mob_hard")) {
            fireRate = (float)((double)conf["mob"]["mob_hard"]["fireRate"]);
        }

        bulletControl bulletCtrl = bullet.GetComponent<bulletControl>();
        bulletCtrl.setMaster(gameObject);
	}

	// Update is called once per frame
	void Update () {
        if (Time.time > nextFire) {
            nextFire += fireRate;

            if (gameObject.transform.name.Contains("mob_mid")) {
                Bounds bounds = gameObject.GetComponent<SpriteRenderer>().bounds;
                Vector3 center = bulletBhvCtrl.NormalizedCenter(gameObject.transform.position, bounds);
                Vector3 pos_bullet_create = center + new Vector3(0, -0.6f, 0);
                bulletBhvCtrl.ShotBehaviorNormal(gameObject, bullet, pos_bullet_create);
            }
            if (gameObject.transform.name.Contains("mob_hard")) {
                bulletBhvCtrl.ShotBehaviorCircle(gameObject, bullet, 6);
            }

            if (gameObject.transform.name.Contains("mob_boss")) {
                bulletBhvCtrl.ShotBehaviorCirculor(gameObject, bullet, curAngle);
            }

            curAngle += nextRange;
        }

	}
}
