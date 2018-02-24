using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour {

    // Use this for initialization
    float bullet_speed = 3f;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up * bullet_speed;
    }
}
