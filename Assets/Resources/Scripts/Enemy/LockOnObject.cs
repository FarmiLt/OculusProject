using UnityEngine;
using System.Collections;

///--------------------------------------------------------------
/// <summary>
/// ロックオンされるオブジェクトのクラス
/// </summary>
///--------------------------------------------------------------
public class LockOnObject : MonoBehaviour 
{
    /*** メンバ変数 ***/
    private GameObject m_lockOnMaker;
    private GameObject m_prefabMaker;

    ///--------------------------------------------------------------
	/// <summary>
	/// 開始処理
	/// </summary>
    ///--------------------------------------------------------------
	void Awake ()
    {
        // 生成するマーカのプレハブを取得
        m_prefabMaker = LockOnManager.GetInstance().m_prefabMaker;
	}

    ///--------------------------------------------------------------
	/// <summary>
	/// 更新処理
	/// </summary>
    ///--------------------------------------------------------------
	void Update () {
	
	}

    ///--------------------------------------------------------------
    /// <summary>
    /// カメラに写った時に実行される処理
    /// </summary>
    ///--------------------------------------------------------------
    void OnWillRenderObject() 
    {
        // メインカメラに写った時
        if (Camera.current.tag == "MainCamera") 
        {
            // 生成するプレハブを設定
            if( m_prefabMaker == null ){
                m_prefabMaker = LockOnManager.GetInstance().m_prefabMaker;
            }

            // マーカが存在するときに実行
            if( m_lockOnMaker == null )
            {
                // マーカの数が生成できるか判定
                if( LockOnManager.GetInstance().GetMakerMaxState() == false )
                {
                    // マーカを生成
                    m_lockOnMaker = Instantiate(m_prefabMaker, transform.position, Quaternion.identity) as GameObject;
                    m_lockOnMaker.transform.SetParent(LockOnManager.GetInstance().gameObject.transform);
                    
                    // カメラ取得
                    Camera mainCamera = LockOnManager.GetInstance().m_mainCamera;
                    m_lockOnMaker.GetComponent<ChaseTarget>().SetCameraAndTarget(mainCamera, gameObject);
                }
            }
        }
    }
}
