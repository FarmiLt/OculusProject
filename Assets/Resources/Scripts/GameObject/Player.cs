/****************************************
 * プレイヤークラス
 ****************************************/
using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

	// メンバ変数
	public float m_pitchAngle;		// 上下回転角度
	public float m_yawAngle;		// 左右回転角度

	
	/**********************
	 *  更新処理
	 **********************/
	void Update () {
		if ( Input.GetKey (KeyCode.J) ){
			this.transform.Rotate (new Vector3(0f, -1f, 0f));
		}
		if ( Input.GetKey (KeyCode.L) ){
			this.transform.Rotate (new Vector3(0f, 1f, 0f));
		}
	}
}
