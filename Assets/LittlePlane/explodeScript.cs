using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeScript : MonoBehaviour {

	void AnimationEnd() {
        Destroy (gameObject); //消滅物件
    }
}
