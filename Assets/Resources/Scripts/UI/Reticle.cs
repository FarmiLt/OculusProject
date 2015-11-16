using UnityEngine;
using System.Collections;

public class Reticle : MonoBehaviour {

	[SerializeField]
	private GameObject pedestal;

	[SerializeField]
	private float distance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = pedestal.transform.position;
		transform.position += pedestal.transform.forward * distance;
		transform.LookAt (pedestal.transform);
	}
}
