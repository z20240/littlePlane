﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundControl : MonoBehaviour {

    private float speed = 0.5f;

    private float backgroundSize = 6.7f;
    private Vector3 ori_ops;
	// Use this for initialization
	void Start () {
        ori_ops = gameObject.transform.position;
	}

	// Update is called once per frame
	void Update () {
        float newPos = Mathf.Repeat(Time.time * speed, backgroundSize);
        transform.position = ori_ops + Vector3.down * newPos;
	}
}
