/****************************************
 * 戦車クラス
 ****************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Tank : MonoBehaviour {

	// メンバ変数
	public float m_startAngle;						// 初期での向いている角度
	public float m_rotateValue;						// 回転量
	public float m_moveSpeed;						// 移動速度

	private float m_yawAngle;						// 左右回転角度
	private float m_pitchAngle;						// 上下回転角度
	[SerializeField]private float 				m_currentAngle;		// 現在のフレームでの向いている角度
	[SerializeField]private BaseStrategy<Tank> 	m_currentAttack;	// 現在の攻撃タイプ
	private List<BaseStrategy<Tank>>			m_attackList;		// 攻撃タイプリスト


	public ParticleSystem m_ps;

	/**********************
	 *  初期化処理
	 **********************/
	public void Initialize(){
		m_currentAngle = m_startAngle;
	}

	
	/**********************
	 *  更新処理
	 **********************/
	void Update () {
		ExecuteKeyEvent();

		CalculateDirection ();
	}


	/**********************
	 *  キー処理
	 **********************/
	private void ExecuteKeyEvent(){
		if ( Input.GetKey (KeyCode.A) ){
			m_currentAngle -= m_rotateValue;
		}
		
		if ( Input.GetKey (KeyCode.D) ){
			m_currentAngle += m_rotateValue;
		}

		if ( Input.GetKey (KeyCode.W) ){
			AdvancedForward();
		}
	}


	/**********************
	 *  直進処理
	 **********************/
	public void AdvancedForward(){
		this.transform.localPosition += new Vector3( m_moveSpeed * Mathf.Sin(Mathf.Deg2Rad * m_currentAngle),
		                                             0f,
		                                             m_moveSpeed * Mathf.Cos(Mathf.Deg2Rad * m_currentAngle));
	}


	/**********************
	 *  タンクの向き計算処理
	 **********************/
	public void LeaveBehind(){
	}


	/**********************
	 *  タンクの向き計算処理
	 **********************/
	private void CalculateDirection(){
		this.transform.localRotation = Quaternion.Euler( new Vector3(0f, m_currentAngle, 0f) );
	}

}
