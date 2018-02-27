using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarseMob : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider == null) return;
        // Debug.Log("=========== is " + collider.tag);
        if (collider.tag == "Mob") {
            Destroy(collider.gameObject);
        }
    }
}
