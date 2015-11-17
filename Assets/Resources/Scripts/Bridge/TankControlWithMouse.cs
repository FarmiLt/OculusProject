/**************************************
 *  マウスによるタンクコントロールクラス
 **************************************/
using UnityEngine;
using System.Collections;
using System;


public class TankControlWithMouse : BaseTankControl {


	// マウス列挙型
	public enum eMOUSEBUTTON{
		LEFT = 0,
		RIGHT = 1,
		MIDDLE = 2,
	}


	// メンバ変数
	public Vector2  m_previousMousePos;	// 前回のマウス座標
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
		GetMousePosition();
		m_previousMousePos = m_currentMousePos;

	}


	/**********************
	 *  実行処理
	 **********************/
	public override void Execute(){

		GetMousePosition();

		Vector2 mouseMove = m_currentMousePos - m_previousMousePos;
		Debug.Log ("MouseMove : " + mouseMove.x);

		// 左右回転
		m_owner.YawAngle += mouseMove.x * 0.1f;
		// 上下回転
		m_owner.PitchAngle += mouseMove.y * 0.1f;

		if ( Input.GetMouseButton((int)eMOUSEBUTTON.LEFT) ){
			// 前進
			m_owner.AdvancedForward();
		}
		if ( Input.GetMouseButton((int)eMOUSEBUTTON.RIGHT) ){
			// 後退
			m_owner.LeaveBehind();
		}

		m_previousMousePos = m_currentMousePos;
	}


	/**********************
	 *  マウス座標取得処理
	 **********************/
	public void GetMousePosition(){
		// マウスのスクリーン座標取得
		Vector3 mousePos = Input.mousePosition;
		m_currentMousePos = new Vector2(mousePos.x, mousePos.y);
	}

}
