using UnityEngine;
using System.Collections;

public class FadeManager : MonoBehaviour {

	private Texture2D tex;
	private float fadeAlpha = 0;
	[System.Serializable]
	public class FadeInfo {
		public Color fadeColor;
		public float fadeOutTime_secs;
		public float waitTime_secs;
		public float fadeInTime_secs;
		public bool useFade;
		public string nextScene;
	};

	private FadeInfo fadeInfo;

	public delegate void FadeMethod ();
	public event FadeMethod OnBeforeFadeOut;
	public event FadeMethod OnAfterFadeOut;
	public event FadeMethod OnBeforeFadeIn;
	public event FadeMethod OnAfterFadeIn;

	void Awake () {
		DontDestroyOnLoad (gameObject);

		tex = new Texture2D (1, 1, TextureFormat.ARGB32, false);
		tex.SetPixel (0, 0, Color.white);
		tex.Apply ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartFade (FadeInfo fadeInfo) {
		StartCoroutine (Fade (fadeInfo));
	}

	public IEnumerator Fade (FadeInfo fadeInfo) {

		if (OnBeforeFadeOut != null) {
			OnBeforeFadeOut ();
		}

		this.fadeInfo = fadeInfo;
		GameObject eventSystem = GameObject.Find ("EventSystem");
		if (eventSystem != null) {
			eventSystem.SetActive (false);
		}

		float time = 0;
		while (time < fadeInfo.fadeOutTime_secs) {
			fadeAlpha = time / fadeInfo.fadeOutTime_secs;
			time += Time.deltaTime;
			yield return null;
		}

		if (OnAfterFadeOut != null) {
			OnAfterFadeOut ();
		}

		if (fadeInfo.useFade) {
			Application.LoadLevel (fadeInfo.nextScene);
			yield return null;
		}
		eventSystem = GameObject.Find ("EventSystem");
		if (eventSystem != null) {
			eventSystem.SetActive (false);
		}

		yield return new WaitForSeconds (fadeInfo.waitTime_secs);

		if (OnBeforeFadeIn != null) {
			OnBeforeFadeIn ();
		}

		time = 0;
		while (time < fadeInfo.fadeInTime_secs) {
			fadeAlpha = 1 - (time / fadeInfo.fadeInTime_secs);
			time += Time.deltaTime;
			yield return null;
		}

		if (OnAfterFadeIn != null) {
			OnAfterFadeIn ();
		}

		if (eventSystem != null) {
			eventSystem.SetActive (true);
		}

		this.fadeInfo = null;

		OnBeforeFadeOut = null;
		OnAfterFadeOut = null;
		OnBeforeFadeIn = null;
	    OnAfterFadeIn = null;
	}

	public void OnGUI () {
		if (fadeInfo == null)
			return;

		if (fadeAlpha == 0)
			return;

		GUI.color = new Color (fadeInfo.fadeColor.r, fadeInfo.fadeColor.g, fadeInfo.fadeColor.b, fadeAlpha);
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), tex);
	}
}
