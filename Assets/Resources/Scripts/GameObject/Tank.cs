/****************************************
 * 戦車クラス
 ****************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Tank : MonoBehaviour {

	// メンバ変数
	public BaseTankControl	m_tankController = null;	// タンクコントロールクラス
	public float 			m_startAngle;				// 初期での向いている角度
	public float 			m_rotateValue;				// 回転量
	public float 			m_moveSpeed;				// 移動速度

	[SerializeField]private float 				m_yawAngle;			// 左右回転角度
	[SerializeField]private float 				m_pitchAngle;		// 上下回転角度
	[SerializeField]private BaseStrategy<Tank> 	m_currentAttack;	// 現在の攻撃タイプ
	private List<BaseStrategy<Tank>>			m_attackList;		// 攻撃タイプリスト
	private MachineGun							m_machineGun;		// マシンガン

	// プロパティ
	public float YawAngle{
		set{ m_yawAngle = value; }
		get{ return m_yawAngle;}
	}
	public float PitchAngle{
		set{ 
			m_pitchAngle = value;
			m_pitchAngle = Mathf.Clamp (m_pitchAngle, 
			                            ConstantDataManager.Instance.pitchMin,
			                            ConstantDataManager.Instance.pitchMax);
		}
		get{ return m_pitchAngle; }
	}
	public float RotateValue{
		get{ return m_rotateValue; }
	}



	/**********************
	 *  生成時処理
	 **********************/
	void Start(){
		Initialize ();
	}


	/**********************
	 *  初期化処理
	 **********************/
	public void Initialize(){
		m_yawAngle = m_startAngle;
		m_machineGun = this.transform.FindChild("MachineGun").FindChild("Barrel").GetComponent<MachineGun>();

		// マウスによるタンクコントロールを代入
		m_tankController = new TankControlWithMouse(this);
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
		// タンクコントロールクラスに依存
		if ( m_tankController != null ){
			m_tankController.Execute ();
		}
	}


	/**********************
	 *  直進処理
	 **********************/
	public void AdvancedForward(){
		this.transform.localPosition += new Vector3( m_moveSpeed * Mathf.Sin(Mathf.Deg2Rad * m_yawAngle),
		                                             0f,
		                                             m_moveSpeed * Mathf.Cos(Mathf.Deg2Rad * m_yawAngle));
	}


	/**********************
	 *  後退処理
	 **********************/
	public void LeaveBehind(){
		this.transform.localPosition -= new Vector3(m_moveSpeed * Mathf.Sin(Mathf.Deg2Rad * m_yawAngle),
		                                            0f,
		                                            m_moveSpeed * Mathf.Cos(Mathf.Deg2Rad * m_yawAngle));
	}


	#region 装備による攻撃==============================================================

	/**********************
	 *  発射処理
	 **********************/
	public void Fire(){
		m_machineGun.PullTrigger();
	}


	/**********************
	 *  打ち止め処理
	 **********************/
	public void StopFire(){
		m_machineGun.ReleaseTrigger();
	}

	#endregion ========================================================================
	

	/**********************
	 *  タンクの向き計算処理
	 **********************/
	private void CalculateDirection(){
		this.transform.localRotation = Quaternion.Euler( new Vector3(m_pitchAngle, m_yawAngle, 0f) );

	}

}
