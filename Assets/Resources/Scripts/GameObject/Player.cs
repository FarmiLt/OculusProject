/****************************************
 * プレイヤークラス
 ****************************************/
using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

	// メンバ変数
	private Tank	m_tank;		// タンク


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
		if ( Input.GetKeyDown(KeyCode.Space) ){
			m_tank.Fire ();
		}
		if ( Input.GetKeyUp(KeyCode.Space) ){
			m_tank.StopFire();
		}
	}
}
