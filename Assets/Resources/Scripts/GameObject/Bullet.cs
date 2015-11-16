using UnityEngine;
using System.Collections;

public class Bullet : BaseBullet {


	/**********************
	 *  衝突時処理
	 **********************/
	void OnCollisionEnter(Collision _opponent ){
	}


	/**********************
	 *  初期化処理
	 **********************/
	public override void Initialize(){
	}


	/**********************
	 *  更新処理
	 **********************/
	void Update () {
		// ある程度飛んだら消滅
		if ( m_timer >= m_disappearTime ){
			Destroy (this.gameObject);
		}

		m_timer += Time.deltaTime;
	}
}
