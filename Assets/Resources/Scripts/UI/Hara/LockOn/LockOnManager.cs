using UnityEngine;
using System.Collections;

///--------------------------------------------------------------
/// <summary>
/// ロックオンマネージャ
/// </summary>
///--------------------------------------------------------------
public class LockOnManager : MonoBehaviour 
{
    /*** 外部アクセス ***/
    public GameObject m_prefabMaker;
    public Camera m_mainCamera;

    /*** メンバ変数 ***/
    private int m_maxMakerCount;
    private int m_makerCount;
    private bool m_isMakerMax;

    /*** static変数 ***/
    private static LockOnManager m_instance;

    ///--------------------------------------------------------------
    /// <summary>
    /// ゲットインスタンス
    /// </summary>
    /// <returns></returns>
    ///--------------------------------------------------------------
    public static LockOnManager GetInstance()
    {
        if( m_instance == null )
        {
            GameObject go = new GameObject("");
            m_instance = go.AddComponent<LockOnManager>();
        }

        return m_instance;
    }

    ///--------------------------------------------------------------
    /// <summary>
    /// マーカの数が最大化判定するゲッター
    /// </summary>
    /// <returns></returns>
    ///--------------------------------------------------------------
    public bool GetMakerMaxState()
    {
        // マーカが最大でなかったらfalseを返す
        if (m_makerCount < m_maxMakerCount){
            m_isMakerMax = false;
        }
        // 最大だったらtrueを返す
        else{
            m_isMakerMax = true;
        }

        return m_isMakerMax;
    }

    ///--------------------------------------------------------------
    /// <summary>
    /// 開始処理
    /// </summary>
    ///--------------------------------------------------------------
    void Awake()
    {
        m_instance = this;
        m_maxMakerCount = 3;
        m_makerCount = 0;
        m_isMakerMax = false;
    }

    ///--------------------------------------------------------------
    /// <summary>
    /// 更新処理
    /// </summary>
    ///--------------------------------------------------------------
	void Update () 
    {
        
	}
}
