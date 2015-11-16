using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReloadGauge : MonoBehaviour {

	[SerializeField]
	private float reloadTime_secs = 0;

	public delegate void OnFinishedReload ();
	public event OnFinishedReload onFinishedReload;

	// Use this for initialization
	void Start () {
		StartCoroutine (Reload ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator Reload () {
		float time = 0;
		while (time < reloadTime_secs) {
			GetComponent<Image> ().fillAmount = Mathf.Lerp (0, 1, time / reloadTime_secs);
			time += Time.deltaTime;
			yield return null;
		}
		GetComponent<Image> ().fillAmount = 1;

		if (onFinishedReload != null) {
			onFinishedReload ();
		}

		yield return null;
		Destroy (transform.parent.gameObject);
	}
}
