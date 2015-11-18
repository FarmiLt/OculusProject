/****************************************
 * 戦車クラス
 ****************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Tank : MonoBehaviour {


	// 銃タイプ列挙型
	public enum eGUNTYPE{
		MACHINEGUN = 0,
		LASER,

		TYPE_MAX,
	}


	// メンバ変数
	[SerializeField] private GameObject[] m_guns;		// 銃オブジェクト(左,右の順に追加してくだちい)
	public BaseTankControl	m_tankController = null;	// タンクコントロールクラス
	public float 			m_startAngle;				// 初期での向いている角度
	public float 			m_rotateValue;				// 回転量
	public float 			m_moveSpeed;				// 移動速度
	public int 				m_currentGunType;			// 現在の銃タイプ
	public int				m_previousGunType;			// 1つ前の銃タイプ

	[SerializeField]private float 	m_yawAngle;						// 左右回転角度
	[SerializeField]private float 	m_pitchAngle;					// 上下回転角度
	private Wepon[]					m_equipGuns = new Wepon[2];		// 現在装備している銃
	

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
	 *  武器チェンジ処理
	 **********************/
	public void ChangeWeapon(){
		m_previousGunType = m_currentGunType;

		// カウントアップ
		m_currentGunType = (m_currentGunType + 1) % (int)eGUNTYPE.TYPE_MAX;

		SetWeapon ();
		ShowWeapon();
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
		m_rotateValue = ConstantDataManager.Instance.tankTurningValue;

		// 武器の設定
		SetWeapon();

		// マウスによるタンクコントロールを代入
		m_tankController = new TankControlWithMouse(this);
	}

	
	/**********************
	 *  更新処理
	 **********************/
	void Update () {
		ExecuteKeyEvent();
		CalculateDirection();
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
		foreach( Wepon gun in m_equipGuns ){
			gun.PullTrigger();
		}
	}


	/**********************
	 *  打ち止め処理
	 **********************/
	public void StopFire(){
		foreach( Wepon gun in m_equipGuns ){
		gun.ReleaseTrigger();
		}
	}


	/**********************
	 *  銃の切り換え処理
	 **********************/
	public void SetWeapon(){
		for( int i = 0; i < 2; ++i ){
			m_equipGuns[i] = m_guns[i + m_currentGunType * (int)eGUNTYPE.TYPE_MAX].GetComponent<Wepon>();
		}
	}


	/**********************
	 *  銃の表示・非表示処理
	 **********************/
	public void ShowWeapon(){
		for ( int i = 0; i < 2; ++i ){
			// 武器の表示
			m_guns[i + m_currentGunType * (int)eGUNTYPE.TYPE_MAX].SetActive(true);
			// 武器の非表示
			m_guns[i + m_previousGunType * (int)eGUNTYPE.TYPE_MAX].SetActive(false);
		}
	}


	#endregion ========================================================================
	

	/**********************
	 *  タンクの向き計算処理
	 **********************/
	private void CalculateDirection(){
		this.transform.localRotation = Quaternion.Euler( new Vector3(m_pitchAngle, m_yawAngle, 0f) );

	}

}
