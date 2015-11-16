﻿using UnityEngine;
using System.Collections;

public class TestGunController : MonoBehaviour {

	public GameObject gun;
	MachineGun gunScript;

	// Use this for initialization
	void Start () {
		gunScript = gun.GetComponent<MachineGun>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
		{
			gunScript.PullTrigger();
		}
		if(Input.GetKeyUp(KeyCode.A))
		{
			gunScript.ReleaseTrigger();
		}
	
	}
}
