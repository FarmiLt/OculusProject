/****************************************
 * ストラテジークラス基盤
 ****************************************/
using UnityEngine;
using System.Collections;


public class BaseStrategy<Type> where Type : class {	

	// メンバ変数
	private Type m_owner;	// 自身の所有者


	/**********************
	 *  コンストラクタ
	 **********************/
	BaseStrategy(Type _owner){
		m_owner = _owner;
	}


	/**********************
	 *  実行処理
	 **********************/
	public virtual void Execute(Type owner){}
}
