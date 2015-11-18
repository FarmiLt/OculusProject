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
    public Camera m_mainCamera;
    public GameObject m_target;

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
        // ターゲット座標をスクリーン座標に変換
        Vector3 targetViewportPoint = m_mainCamera.WorldToScreenPoint(m_target.transform.position);
        transform.position = targetViewportPoint;
	}
}
