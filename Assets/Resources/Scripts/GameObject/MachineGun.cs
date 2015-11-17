﻿using UnityEngine;
using System.Collections;

public class MachineGun : Wapon {

	public GameObject bulletPrefab;
	public float fireParSecond;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void PullTrigger()
	{
		//Debug.Log("CreateBullet");
		//GameObject bullet = (GameObject)Instantiate(bulletPrefab,transform.position,Quaternion.identity);
		Debug.Log("PullTrigger");
		StartCoroutine("Rapidfire");
	}

	public void ReleaseTrigger()
	{
		Debug.Log("ReleaseTrigger");
		StopCoroutine("Rapidfire");
	}

	private IEnumerator Rapidfire()
	{
		while(true)
		{
			Fire();

			yield return null;

			if(fireParSecond <= 0.0f)fireParSecond = 0.1f;

			for(int i=0;i<(60/fireParSecond);i++){yield return null;}
		}
	}

	private void Fire()
	{
		Debug.Log("Fire");
		GameObject bullet = (GameObject)Instantiate(bulletPrefab,transform.position,transform.rotation);
	}


	   
}
