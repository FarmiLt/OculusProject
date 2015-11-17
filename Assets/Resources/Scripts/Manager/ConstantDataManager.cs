/****************************************
 * 不変データ管理クラス
 ****************************************/
using UnityEngine;
using System.Collections;

public class ConstantDataManager : SingletonMonoBehaviour<ConstantDataManager> {

	// タンクのデータ
	public float pitchMax;			// 上下回転の上限
	public float pitchMin;			// 上下回転の下限
	public float MouseThreshold;	// マウス反応閾値


	void Awake(){
		if ( this != Instance ){
			Destroy (this.gameObject);
		}

		DontDestroyOnLoad(this.gameObject);
	}


}
