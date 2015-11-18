using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetHitUI : MonoBehaviour {

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private float fadeOutTime_secs = 0;

	[SerializeField]
	private float waitTime_secs = 0;

	private float defaultAngle = 0;

	public float DefaultAngle {
		set {defaultAngle = value;}
	}

	// Use this for initialization
	void Start () {
		defaultAngle = transform.eulerAngles.z;
		player = GameObject.FindWithTag ("Player");
		StartCoroutine (FadeOut ());
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (new Vector3 (0, 0, player.transform.eulerAngles.y) + new Vector3 (0, 0, defaultAngle));
	}

	private IEnumerator FadeOut () {
		yield return new WaitForSeconds (waitTime_secs);

		float time = 0;
		Color imageColor = GetComponent<Image> ().color;
		while (time < fadeOutTime_secs) {
			GetComponent<Image> ().color = new Color (imageColor.r, imageColor.g, imageColor.b, Mathf.Lerp (138f / 255f, 0, time / fadeOutTime_secs));
			time += Time.deltaTime;
			yield return null;
		}
		GetComponent<Image> ().color = new Color (imageColor.r, imageColor.g, imageColor.b, 1);

		Destroy (this.gameObject);
	}
}
