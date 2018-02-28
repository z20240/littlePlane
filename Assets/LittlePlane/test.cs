using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public GameObject bullet;
    private BulletBehaviorCtrl bulletBhvCtrl;
    private GameObject bulletBhvMng;

    private float time;
    private float fireRate = 0.01f;
    private float nextFire = 0.0f;
    private int curAngle = 0;
    private int nextRange = 30;


	void Start () {
        bulletBhvMng = GameObject.Find("BulletBehaviorManager");
        bulletBhvCtrl = bulletBhvMng.GetComponent<BulletBehaviorCtrl>();

	}

	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        Debug.Log("gameObject" + gameObject);
        Debug.Log("bullet" + bullet);

        if (time > nextFire) {
            nextFire += fireRate;
            Vector3 pos_bullet_create = gameObject.transform.position + new Vector3(0, 0.6f, 0);
            // bulletBhvCtrl.ShotBehaviorCircle(gameObject, bullet, 6);
            bulletBhvCtrl.ShotBehaviorCirculor(gameObject, bullet, curAngle);
            bulletBhvCtrl.ShotBehaviorNormal(gameObject, bullet, gameObject.transform.position + new Vector3(0, -0.6f, 0));
            curAngle += nextRange;
        }

	}
}
