using UnityEngine;
using System.Collections;

public class TankControlWithGamePad : BaseTankControl {


	/**********************
	 *  コンストラクタ
	 **********************/
	public TankControlWithGamePad(Tank _tank) : base(_tank){
		Initialize ();
	}
	
	
	/**********************
	 *  初期化処理
	 **********************/
	public override void Initialize(){

	}
	
	
	
	/**********************
	 *  実行処理
	 **********************/
	public override void Execute(){
		m_owner.YawAngle += Input.GetAxis("Horizontaljoy") * m_owner.RotateValue;
		m_owner.PitchAngle += Input.GetAxis("VerticalJoy") * m_owner.RotateValue;
	}

}
