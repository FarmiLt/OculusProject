using UnityEngine;
using System.Collections;


public class BaseBullet : MonoBehaviour {

	// メンバ変数
	public float 	m_disappearTime;	// 消える時間

	protected float m_timer = 0f;		// タイマー


	/**********************
	 *  初期化処理
	 **********************/
	virtual public void Initialize(){}


	/**********************
	 *  更新処理
	 **********************/
	void Update(){
		// 消滅
		if ( m_timer >= m_disappearTime ){
			Destroy(this.gameObject);
		}

		m_timer += Time.deltaTime;
	}
}
