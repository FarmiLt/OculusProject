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

		// カーソルをウィンドウから出さない
		Screen.lockCursor = true;
	}


	/**********************
	 *  実行処理
	 **********************/
	public override void Execute(){

		GetMousePosition();

		// 左右回転
		m_owner.YawAngle += Input.GetAxis ("Mouse ScrollWheel") * m_owner.RotateValue;
		// 上下回転(ホイール奥で右回転)
		m_owner.PitchAngle += Input.GetAxis ("Mouse Y") * -1f;

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
