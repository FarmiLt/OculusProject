using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RemainingBulletUI : MonoBehaviour {

	[SerializeField]
	Text currentBulletNumText;
	[SerializeField]
	Text maxBulletNumText;

	// Use this for initialization
	void Start () {
		UpdateCurrentBulletNum (3);
		SetMaxBulletNum (100);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateCurrentBulletNum (int currentBulletNum) {
		currentBulletNumText.text = currentBulletNum.ToString ();
	}

	void SetMaxBulletNum (int maxBulletNum) {
		maxBulletNumText.text = maxBulletNum.ToString ();
	}
}
