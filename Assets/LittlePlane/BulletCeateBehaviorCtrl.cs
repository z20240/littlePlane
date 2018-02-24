using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCeateBehaviorCtrl : MonoBehaviour {
    public enum BEHAVIOR {UP,DOWN,LEFT,RIGHT,CIRCLE,};
    //旋转改变的角度
    // public int changeAngle = 0;
    //旋转一周需要的预制物体个数
    // private int count;

    public int timesLimit = 100000;
    private float angle = 0;
    private float nextFire = 0.0f;
    public float r = 0.6f;
    public void ShotBehaviorCircle(GameObject go, GameObject bullet, int bulletAmount) {
        int changeAngle = 360 / bulletAmount;

        Vector3 center = NormalizedCenter(go.transform.position, go.GetComponent<SpriteRenderer>().bounds);

        Debug.Log("Bound" + go.GetComponent<SpriteRenderer>().bounds + " normal" + center.normalized);

        float time = 0.0f;
        time += Time.deltaTime;

        GameObject bulletCloneC = (GameObject) Instantiate(bullet, center, new Quaternion());

        for (int i = 0; i < bulletAmount; i++) {

            GameObject bulletClone = (GameObject) Instantiate(bullet);
            float hudu = (angle / 180) * Mathf.PI;
            float xx = center.x + r * Mathf.Cos (hudu);
            float yy = center.y + r * Mathf.Sin (hudu);
            bulletClone.transform.position = new Vector3 (xx, yy, 0);
            // bulletClone.transform.LookAt (center);
            Debug.Log(i + " " + " Time:" + time + " nextFire:" + nextFire);
            angle += changeAngle;
        }
    }

    public void ShotBehaviorCirculor(GameObject go, GameObject bullet, float angle) {
        Vector3 center = NormalizedCenter(go.transform.position, go.GetComponent<SpriteRenderer>().bounds);

        Debug.Log("Bound" + go.GetComponent<SpriteRenderer>().bounds + " postion" + go.transform.position);

        GameObject bulletClone = (GameObject) Instantiate(bullet);

        float hudu = (angle / 180) * Mathf.PI;
        float xx = center.x + r * Mathf.Cos (hudu);
        float yy = center.y + r * Mathf.Sin (hudu);

        bulletClone.transform.position = new Vector3 (xx, yy, 0);
        Debug.Log(bulletClone.transform.position);
        return ;
    }

    // public

    public Vector3 NormalizedCenter(Vector3 location, Bounds bound) {
        return new Vector3(location.x + bound.extents.x, location.y - bound.extents.y, location.z);
    }
}