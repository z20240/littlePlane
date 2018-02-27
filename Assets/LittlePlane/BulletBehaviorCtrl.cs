using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviorCtrl : MonoBehaviour {
    public enum BEHAVIOR {UP,DOWN,LEFT,RIGHT,CIRCLE,};



    private float angle = 0;
    private float nextFire = 0.0f;
    private float r = 0.6f;
    public void ShotBehaviorCircle(GameObject go, GameObject bullet, int bulletAmount) {
        //旋转改变的角度
        int changeAngle = 360 / bulletAmount;
        Bounds bounds = go.GetComponent<SpriteRenderer>().bounds;
        Vector3 center = NormalizedCenter(go.transform.position, bounds);

        // Debug.Log("Bound" + bounds + " normal" + center.normalized);

        float time = 0.0f;
        time += Time.deltaTime;

        for (int i = 0; i < bulletAmount; i++) {

            GameObject bulletClone = (GameObject) Instantiate(bullet);
            bulletClone.GetComponent<bulletControl>().setMaster(go);
            bulletClone.GetComponent<bulletControl>().MasterName = go.name;
            float hudu = (angle / 180) * Mathf.PI;
            float xx = center.x + ( r + bounds.extents.x ) * Mathf.Cos (hudu);
            float yy = center.y + ( r + bounds.extents.y ) * Mathf.Sin (hudu);
            bulletClone.transform.position = new Vector3 (xx, yy, 0);
            // bulletClone.transform.LookAt (center);
            // Debug.Log(i + " " + " Time:" + time + " nextFire:" + nextFire);
            angle += changeAngle;
        }
    }

    public void ShotBehaviorCirculor(GameObject go, GameObject bullet, float angle) {
        Bounds bounds = go.GetComponent<SpriteRenderer>().bounds;
        Vector3 center = NormalizedCenter(go.transform.position, bounds);

        GameObject bulletClone = (GameObject) Instantiate(bullet);
        bulletClone.GetComponent<bulletControl>().setMaster(go);
        bulletClone.GetComponent<bulletControl>().MasterName = go.name;

        float hudu = (angle / 180) * Mathf.PI;
        float xx = center.x + ( r + bounds.extents.x ) * Mathf.Cos (hudu);
        float yy = center.y + ( r + bounds.extents.y ) * Mathf.Sin (hudu);

        bulletClone.transform.position = new Vector3 (xx, yy, 0);
        return ;
    }

    public void ShotBehaviorNormal(GameObject go, GameObject bullet, Vector3 pos_bullet_create) {
        GameObject bulletClone = Instantiate(bullet, pos_bullet_create, go.transform.rotation); // 如果是 UI 的話就要另外設定
        bulletClone.GetComponent<bulletControl>().setMaster(go);
        bulletClone.GetComponent<bulletControl>().MasterName = go.name;
    }

    // public

    public Vector3 NormalizedCenter(Vector3 location, Bounds bound) {
        return new Vector3(location.x + bound.extents.x, location.y - bound.extents.y, location.z);
    }

    public void BulletMove(Vector3 vector, GameObject bullet, float speed) {
        bullet.GetComponent<Rigidbody2D>().velocity = (vector * speed);
    }
}