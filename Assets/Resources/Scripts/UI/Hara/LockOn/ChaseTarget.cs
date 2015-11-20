using UnityEngine;
using System.Collections;

///--------------------------------------------------------------
/// <summary>
/// ターゲットを追うマーカのクラス
/// </summary>
///--------------------------------------------------------------
public class ChaseTarget : MonoBehaviour
{
    /*** メンバ変数 ***/
    private Camera m_mainCamera;
    private GameObject m_target;

    ///--------------------------------------------------------------
    /// <summary>
    /// カメラとターゲットのセッター
    /// </summary>
    /// <param name="camera"></param>
    /// <param name="target"></param>
    ///--------------------------------------------------------------
    public void SetCameraAndTarget( Camera camera, GameObject target )
    {
        m_mainCamera = camera;
        m_target = target;
    }

    ///--------------------------------------------------------------
    /// <summary>
    /// スタート処理
    /// </summary>
    ///--------------------------------------------------------------
	void Start ()
    {
	
	}

    ///--------------------------------------------------------------
    /// <summary>
    /// 更新処理
    /// </summary>
    ///--------------------------------------------------------------
	void Update () 
    {
        if (m_target == null) {
            Destroy(gameObject);
        }
        else
        {
            // ターゲット座標をスクリーン座標に変換
            Vector3 targetViewportPoint = m_mainCamera.WorldToScreenPoint(m_target.transform.position);
            transform.position = targetViewportPoint;
        }
	}
}
