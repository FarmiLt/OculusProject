using UnityEngine;
using System.Collections;

public class MachineGunBullet : MonoBehaviour {

	public float bulletForce;
	private Rigidbody rig;

	// Use this for initialization
	void Start () {
		rig = GetComponent<Rigidbody>();

		rig.AddForce(0.0f,0.0f, bulletForce);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
