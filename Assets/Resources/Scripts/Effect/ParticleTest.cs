using UnityEngine;
using System.Collections;

///------------------------------------------------------------
/// <summary>
/// パーティクルを実行するクラス
/// </summary>
///------------------------------------------------------------
public class ParticleTest : MonoBehaviour
{
    public GameObject[] m_effectArray;

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
        float width = 200.0f;
        float height = 50.0f;

        for( int i = 0; i < m_effectArray.Length; ++i )
        {
            string name = m_effectArray[i].ToString();
            name = name.Replace("(UnityEngine.GameObject)", "");

            if (GUI.Button(new Rect(0, i * height, width, height), name) == true)
            {
                Instantiate( m_effectArray[i] );
            }
        }
    }
}
