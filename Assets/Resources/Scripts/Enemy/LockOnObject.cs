using UnityEngine;
using System.Collections;

public class LockOnObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnWillRenderObject() {
        if (Camera.current.tag == "MainCamera") {



        }
    }

}
