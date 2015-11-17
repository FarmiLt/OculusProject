using UnityEngine;
using System.Collections;

public class LaserLuncher : Wapon {

	public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void PullTrigger()
	{
		StartCoroutine("Irradiating");
	}
	
	public override void ReleaseTrigger()
	{
		StopCoroutine( "Irradiating");
	}

	private IEnumerator Irradiating()
	{
		while(true)
		{
			GameObject bullet = (GameObject)Instantiate(bulletPrefab,transform.position,transform.rotation);
			yield return null;
		}
	}
}
