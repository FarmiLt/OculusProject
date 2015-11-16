/**************************************
 *  マウスによるタンクコントロールクラス
 **************************************/
using UnityEngine;
using System.Collections;


public class TankControlWithMouse : BaseTankControl {

	// メンバ変数
	public Vector2 	m_screenCenter;		// スクリーン中心
	public float 	m_threshold;		// マウス移動の閾値(ゆとり)
	public Vector2	m_currentMousePos;	// マウスの座標

	
	/**********************
	 *  コンストラクタ
	 **********************/
	public TankControlWithMouse(Tank _tank) : base(_tank){
		Initialize ();
	}


	/**********************
	 *  初期化処理
	 **********************/
	public override void Initialize(){
		// スクリーンの中心点取得
		m_screenCenter = new Vector2( Screen.width * 0.5f, Screen.height * 0.5f );
		// マウスの反応閾値を取得
		m_threshold = ConstantDataManager.Instance.MouseThreshold;
	}


	/**********************
	 *  実行処理
	 **********************/
	public override void Execute(){
		// マウスのスクリーン座標取得
		Vector3 mousePos = Input.mousePosition;
		m_currentMousePos = new Vector2(mousePos.x, mousePos.y);

		if ( m_currentMousePos.x >= m_screenCenter.x + m_threshold ){
			// 時計回り
			m_owner.YawAngle += m_owner.RotateValue;
		}
		if ( m_currentMousePos.x <= m_screenCenter.x - m_threshold ){
			// 反時計まわり
			m_owner.YawAngle -= m_owner.RotateValue;
		}
		if ( m_currentMousePos.y <= m_screenCenter.y - m_threshold ){
			// 下を向く
			m_owner.PitchAngle += m_owner.RotateValue;
		}
		if ( m_currentMousePos.y >= m_screenCenter.y + m_threshold ){
			// 上を向く
			m_owner.PitchAngle -= m_owner.RotateValue;
		}
	}
}
