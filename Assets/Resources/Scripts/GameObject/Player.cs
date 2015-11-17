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
		if ( Input.GetKeyDown( KeyCode.Q ) ){
			// 武器切り換え(+)
			m_tank.ChangeWeapon(true);
		}
		if ( Input.GetKeyDown( KeyCode.E ) ){
			// 武器切り換え(-)
			m_tank.ChangeWeapon(false);
		}
		if ( Input.GetKeyDown(KeyCode.Space) ){
			// 撃てぃ！
			m_tank.Fire ();
		}
		if ( Input.GetKeyUp(KeyCode.Space) ){
			// 撃ち方止め！
			m_tank.StopFire();
		}
	}


	/**********************
	 *  向き計算処理
	 **********************/
	public void CulculateDirection(){

	}

}
