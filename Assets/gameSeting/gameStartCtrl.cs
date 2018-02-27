using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gameStartCtrl : MonoBehaviour {

	void Start () {

        GetComponent<Button>().onClick.AddListener(() => {
            // Debug.Log(gameObject.transform.name);
            SceneManager.LoadScene("littlePlane");
        });

	}

	// Update is called once per frame
	void Update () {

	}
}
