using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour {

	[SerializeField]
	private FadeManager.FadeInfo fadeInfo;

	event FadeManager.FadeMethod OnBeforeFadeOut;
	event FadeManager.FadeMethod OnAfterFadeOut;
	event FadeManager.FadeMethod OnBeforeFadeIn;
	event FadeManager.FadeMethod OnAfterFadeIn;


	public void Fade () {
		FadeManager fadeManager = GameObject.FindWithTag ("FadeManager").GetComponent<FadeManager> ();
		if (fadeManager == null)
			return;

		fadeManager.OnAfterFadeIn += OnAfterFadeOut;
		fadeManager.OnAfterFadeIn += OnBeforeFadeOut;
		fadeManager.OnAfterFadeIn += OnAfterFadeIn;
		fadeManager.OnAfterFadeIn += OnBeforeFadeIn;

		fadeManager.StartFade (fadeInfo);
	}
}
