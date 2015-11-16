using UnityEngine;
using System.Collections;


public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour  {

	// メンバ変数
	static private T m_instance = null;

	// プロパティ
	static public T Instance{
		get{
			if (m_instance == null) {
				// オブジェクトを生成
				m_instance = (T)FindObjectOfType(typeof(T));
				if ( m_instance == null ){
					// エラー報告
					Debug.LogError (typeof(T) + "is nothing");
				}
			}

			return m_instance;
		}
	}
}
