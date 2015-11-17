/****************************************
 * 基本タンクコントロールクラス
 ****************************************/
using UnityEngine;
using System.Collections;

public abstract class BaseTankControl {

	// メンバ変数
	protected Tank m_owner = null;


	/**********************
	 *  コンストラクタ
	 **********************/
	public BaseTankControl(Tank _tank){
		m_owner = _tank;
	}


	/**********************
	 *  初期化処理
	 **********************/
	public virtual void Initialize(){}



	/**********************
	 *  実行処理
	 **********************/
	public abstract void Execute();
}
