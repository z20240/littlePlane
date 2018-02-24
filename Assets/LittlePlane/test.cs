using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public GameObject bullet;
    private BulletCeateBehaviorCtrl bulletBhvCtrl;

    private float fireRate = 0.01f;
    private float nextFire = 0.0f;
    private int curAngle = 0;
    private int nextRange = 30;

    GameObject bulletBhvMng;
	void Start () {
        bulletBhvMng = GameObject.Find("BulletBehaviorManager");
        if ( bulletBhvMng == null ) {
            Debug.Log("bulletBhvMng is NULL");
            return;
        }

        bulletBhvCtrl = bulletBhvMng.GetComponent<BulletCeateBehaviorCtrl>();

	}

	// Update is called once per frame
	void Update () {
        Debug.Log("gameObject" + gameObject);
        Debug.Log("bullet" + bullet);

        if (Time.time > nextFire) {
            nextFire += fireRate;
            Vector3 pos_bullet_create = gameObject.transform.position + new Vector3(0, 0.6f, 0);
            // bulletBhvCtrl.ShotBehaviorCircle(gameObject, bullet, 6);
            bulletBhvCtrl.ShotBehaviorCirculor(gameObject, bullet, curAngle);
            curAngle += nextRange;
        }

	}
}
