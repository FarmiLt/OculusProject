/*********************************************************************************************************
 * 
 * ■制作者：原昌志
 * ■制作日：2015/11/22
 * 
 * 
 * 
 * 
 * << 消えるまでの処理の流れ >>
 * CutLife();
 *     ↓
 * CreateStop();
 *     ↓
 * JudgeKill();
 * 
 * << ループの状態を監視する処理 >>
 * LoopState(); 
 * 
 *********************************************************************************************************/

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
    public bool m_isLoop;

    /*** メンバ変数 ***/
    private ParticleSystem[] m_particleSystemArray;
    private int m_particleCount;

    /*** 定数 ***/
    private const float KILL_LIFE = 0.0f;

    ///--------------------------------------------------------------
    /// <summary>
    /// 開始処理
    /// </summary>
    ///--------------------------------------------------------------
	void Awake () 
    {
        // 子のパーティクルシステムを取得
        m_particleSystemArray = gameObject.GetComponentsInChildren<ParticleSystem>();

        // 子のパーティクルシステムの数を取得する
        m_particleCount = transform.childCount;

        // 子のパーティクルシステムを取得出来なかった場合はここで終了
        if (m_particleSystemArray == null) return;

        // コルーチンを開始する
        StartCoroutine( CutLife() );        // 寿命を削る処理
        StartCoroutine( LoopState() );      // パーティクルシステムのループの状態の処理
	}

    ///--------------------------------------------------------------
    /// <summary>
    /// ループを有効にする
    /// </summary>
    ///--------------------------------------------------------------
    public void LoopOn()
    {
        m_isLoop = true;
    }

    ///--------------------------------------------------------------
    /// <summary>
    /// ループを無効にする
    /// </summary>
    ///--------------------------------------------------------------
    public void LoopOff()
    {
        m_isLoop = false;
    }

    ///--------------------------------------------------------------
    /// <summary>
    /// パーティクルシステムのループの状態の処理
    /// </summary>
    /// <returns></returns>
    ///--------------------------------------------------------------
    private IEnumerator LoopState()
    {
        // ループの状態を監視する
        while( true )
        {
            // 子のパーティクルシステムすべてにループ状態を適応
            for (int i = 0; i < m_particleCount; ++i)
            {
                // ループフラグの状態をパーティクルシステムの反映させる
                m_particleSystemArray[i].loop = m_isLoop;
            }

            // ループを一時的に抜ける
            yield return null;
         }
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

        // 作るのを止める処理に移行
        yield return StartCoroutine(CreateStop());
    }

    ///--------------------------------------------------------------
    /// <summary>
    /// 作るのをやめる処理
    /// </summary>
    /// <returns></returns>
    ///--------------------------------------------------------------
    private IEnumerator CreateStop()
    {
        // パーティクルシステムのループが有効の時はここで処理を更新しない
        while( m_isLoop == true ) {
            yield return null;
        }

        // パーティクルシステムのループが無効の時はパーティクルが出るのを止める
        for (int i = 0; i < m_particleCount; ++i)
        {
            // ループを無効化
            m_particleSystemArray[i].Stop();
        }

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
        // 配列を初期化
        int array = 0;

        // すべてのパーティクルシステムが終了したか判断
        while (array < m_particleCount)
        {
            // パーティクルが存在しているか判断
            if (m_particleSystemArray[array].isPlaying == false)
            {
                // カウントを増やす
                array++;
            }

            // ループを一時抜ける
            yield return null;
        }

        // 削除
        Destroy(gameObject);
    }
}