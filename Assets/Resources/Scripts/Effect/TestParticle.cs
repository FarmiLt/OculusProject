using UnityEngine;
using System.Collections;

///------------------------------------------------------------
/// <summary>
/// パーティクルを実行するクラス
/// </summary>
///------------------------------------------------------------
public class TestParticle : MonoBehaviour
{
    public GameObject[] m_effectArray;
    private GameObject m_particle;
    private int m_count;

    ///------------------------------------------------------------
    /// <summary>
    /// スタート処理
    /// </summary>
    ///------------------------------------------------------------
	void Start ()
    {
	
	}

    ///------------------------------------------------------------
    /// <summary>
    /// 更新処理
    /// </summary>
    ///------------------------------------------------------------
	void Update ()
    {
	
	}

    ///------------------------------------------------------------
    /// <summary>
    /// GUI処理
    /// </summary>
    ///------------------------------------------------------------
    void OnGUI()
    {
        // 幅・高さ
        float width = 200.0f;
        float height = 50.0f;

        // パーティクルの数だけボタンを生成する
        for( int i = 0; i < m_effectArray.Length; ++i )
        {
            // ボタンに書く文字を調整する
            string name = m_effectArray[i].ToString();
            name = name.Replace("(UnityEngine.GameObject)", "");

            // ボタン生成
            if (GUI.Button(new Rect(0, i * height, width, height), name) == true)
            {
                // ボタンを押すとパーティクルを生成
                Instantiate(m_effectArray[i]);
            }
        }
    }
}
