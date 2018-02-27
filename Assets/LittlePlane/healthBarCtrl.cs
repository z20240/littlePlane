using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarCtrl : MonoBehaviour {
	private float ori_length;

	void Start () {
        ori_length = gameObject.transform.localScale.x;

	}

	// Update is called once per frame
	void Update () {

	}

    public void changeHealBar(int oriHp, int newHp) {
        // Debug.Log("[length]" + gameObject.transform.localScale);
        gameObject.transform.localScale = new Vector3((float)(ori_length * newHp / oriHp), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }
}
