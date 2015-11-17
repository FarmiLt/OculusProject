using UnityEngine;
using System.Collections;

///--------------------------------------------------------------
/// <summary>
/// パーティクルのオブジェクトクラス
/// </summary>
///--------------------------------------------------------------
public class ParticleObject : MonoBehaviour 
{
    private ParticleSystem m_particle;

    ///--------------------------------------------------------------
    /// <summary>
    /// スタート処理
    /// </summary>
    ///--------------------------------------------------------------
	void Start () 
    {
        m_particle = this.GetComponent<ParticleSystem>();
	}

    ///--------------------------------------------------------------
    /// <summary>
    /// 更新処理
    /// </summary>
    ///--------------------------------------------------------------
	void Update () 
    {
        Debug.Log(m_particle.duration);
	}
}
