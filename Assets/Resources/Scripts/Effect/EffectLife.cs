using UnityEngine;
using System.Collections;

///--------------------------------------------------------------
/// <summary>
/// エフェクトの寿命管理のクラス
/// </summary>
///--------------------------------------------------------------
public class EffectLife : MonoBehaviour 
{
    /*** 外部アクセス ***/
    public float m_lifeSecond;

    /*** メンバ変数 ***/
    private ParticleSystem m_particleSystem;

    /*** 定数 ***/
    private const float KILL_LIFE = 0.0f;

    ///--------------------------------------------------------------
    /// <summary>
    /// 開始処理
    /// </summary>
    ///--------------------------------------------------------------
	void Awake () 
    {
        m_particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();

        // 子のパーティクルシステムを取得出来なかった場合はここで終了
        if (m_particleSystem == null) return;

        // コルーチンを開始する
        StartCoroutine( CutLife() );
	}

    ///--------------------------------------------------------------
    /// <summary>
    /// 更新処理
    /// </summary>
    ///--------------------------------------------------------------
	void Update ()
    {
	
	}

    ///--------------------------------------------------------------
    /// <summary>
    /// 寿命を削る処理
    /// </summary>
    /// <returns></returns>
    ///--------------------------------------------------------------
    private IEnumerator CutLife()
    {
        // 寿命がなくなるまで毎フレーム削る
        while( m_lifeSecond > KILL_LIFE )
        {
            // 寿命を減らす
            m_lifeSecond -= Time.deltaTime;
            yield return null;
        }

        yield return StartCoroutine(CreateStop());
    }

    ///--------------------------------------------------------------
    /// <summary>
    /// 作るのをやめる
    /// </summary>
    /// <returns></returns>
    ///--------------------------------------------------------------
    private IEnumerator CreateStop()
    {
        // パーティクルシステムのループが有効の時はここで処理を更新しない
        while( m_particleSystem.loop == true )
        {
            yield return null;
        }

        // パーティクルシステムのループが無効の時はパーティクルが出るのを止める
        m_particleSystem.Stop();

        // パーティクルシステムを削除するか判断する処理に移行
        yield return StartCoroutine(JudgeKill());
    }

    ///--------------------------------------------------------------
    /// <summary>
    /// パーティクルシステムを削除するか判断
    /// </summary>
    /// <returns></returns>
    ///--------------------------------------------------------------
    private IEnumerator JudgeKill()
    {
        // すべてのパーティクルシステムが終了したか判断
        while( m_particleSystem.isPlaying == false )
        {
            // パーティクルシステムを削除
            Destroy(gameObject);
            yield return null;
        }
    }
}
