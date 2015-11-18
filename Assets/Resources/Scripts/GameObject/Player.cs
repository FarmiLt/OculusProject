/****************************************
 * プレイヤークラス
 ****************************************/
using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

	// メンバ変数
	private Tank	m_tank;			// タンク
	private float 	m_yawAngle;		// 左右回転角度
	private float 	m_pitchAngle;	// 上下回転角度

	/**********************
	 *  生成時処理
	 **********************/
	void Start(){
		m_tank = this.transform.parent.GetComponent<Tank>();
	}

		
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


	/**********************
	 *  向き計算処理
	 **********************/
	public void CulculateDirection(){

	}

}
