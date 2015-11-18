using UnityEngine;
using System.Collections;

public class BiologicalWeaponGenerator : MonoBehaviour {

	[SerializeField]
	private float radius;
	[SerializeField]
	private float generationInterval;

	// Use this for initialization
	void Start () {
		StartCoroutine (Generate ());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator Generate () {
		Vector3 vec = new Vector3 (0, 0, 1);
		vec = Quaternion.Euler (0, Random.Range (0f, 360f), 0) * vec;
		Instantiate (Resources.Load ("Prefabs/Enemy/BiologicalWeapon"), vec * radius, Quaternion.identity);
		yield return new WaitForSeconds (generationInterval);
		StartCoroutine (Generate ());
	}
}
