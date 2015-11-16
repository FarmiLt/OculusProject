using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillGauge : MonoBehaviour {

	[SerializeField]
	private float maxSkillGauge;
	[SerializeField]
	private float currentSkillGauge;

	public float MaxSkillGauge {
		set {maxSkillGauge = value;}
	}

	public float CurrentSkillGauge {
		set {currentSkillGauge = value;}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Image> ().fillAmount = Mathf.Lerp (0, 1, currentSkillGauge / maxSkillGauge);
	}
}
