using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPUI : MonoBehaviour {

	[SerializeField]
	private float maxHP;
	[SerializeField]
	private float currentHP;

	private Color uiColor;

	public float MaxHP {
		set {maxHP = value;}
	}

	public float CurrentHP {
		set {currentHP = value;}
	}

	// Use this for initialization
	void Start () {
		uiColor = GetComponent<Image> ().color;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Image> ().color = new Color (uiColor.r, uiColor.g, uiColor.b, Mathf.Lerp (0, 1, currentHP / maxHP));
	}
}
