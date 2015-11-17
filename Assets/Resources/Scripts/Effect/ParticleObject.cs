using UnityEngine;
using System.Collections;

///--------------------------------------------------------------
/// <summary>
/// パーティクルのオブジェクトクラス
/// </summary>
///--------------------------------------------------------------
public class ParticleObject : MonoBehaviour 
{
    /*** メンバ変数 ***/
    private ParticleSystem m_particle;
    private float m_life;
    private bool m_isKill;

    /*** 定数 ***/
    private const float KILL_TIME = 0.0f;

    ///--------------------------------------------------------------
    /// <summary>
    /// 開始処理
    /// </summary>
    ///--------------------------------------------------------------
	void Awake () 
    {
        m_particle = this.GetComponent<ParticleSystem>();
        m_life = m_particle.duration;
        m_isKill = false;

        // 寿命を削る処理を開始する
        StartCoroutine( CutLife() );
	}

    ///--------------------------------------------------------------
    /// <summary>
    /// 更新処理
    /// </summary>
    ///--------------------------------------------------------------
	void Update () 
    {



        //// 寿命が尽きたか判断する
        //if( m_isKill == true )
        //{
        //    // ループするか判断
        //    if (m_particle.loop == false)
        //    {
        //        // パーティクルが出るのを止める
        //        m_particle.Stop();
        //
        //        // 子があるか判断
        //        if (gameObject.transform.childCount > 0)
        //        {
        //            // 子のパーティクルの生成を止める
        //            gameObject.transform.GetComponentInChildren<ParticleObject>().CreateStop();
        //        }
        //    }
        //    else
        //    {
        //        // 子があるか判断
        //        if (gameObject.transform.childCount > 0)
        //        {
        //            // 子のパーティクルの生成を止める
        //            gameObject.transform.GetComponentInChildren<ParticleObject>().CreateKeep();
        //        }
        //    }
        //}


        // すべてのパーティクルが終了したか判断
        if (m_particle.isPlaying == false)
        {
            // パーティクルを削除
            Destroy(gameObject);
        }
	}


    ///--------------------------------------------------------------
    /// <summary>
    /// 寿命を削る
    /// </summary>
    /// <returns></returns>
    ///--------------------------------------------------------------
    private IEnumerator CutLife()
    {
        // 寿命がなくなるまで削る
        while( m_life > KILL_TIME )
        {
            // 寿命を減らす
            m_life -= Time.deltaTime;
            yield return null;
        }

        // パーティクルシステムがループしない状態だったらこれ以上パーティクルを生成しない
        if( m_particle.loop == false )
        {
            // パーティクルを生成しない
            this.CreateStop();
        }
        
        yield return null;
    }

    ///--------------------------------------------------------------
    /// <summary>
    /// パーティクルを維持する
    /// </summary>
    ///--------------------------------------------------------------
    public void CreateKeep()
    {
        m_particle.loop = true;
    }

    ///--------------------------------------------------------------
    /// <summary>
    /// パーティクルを作るのをやめる
    /// </summary>
    ///--------------------------------------------------------------
    public void CreateStop()
    {
        m_particle.Stop();
    }
}
