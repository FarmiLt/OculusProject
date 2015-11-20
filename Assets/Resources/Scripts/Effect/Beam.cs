using UnityEngine;
using System.Collections;

///--------------------------------------------------------------
/// <summary>
/// ビームのクラス
/// </summary>
///--------------------------------------------------------------
public class Beam : MonoBehaviour 
{
    /*** 外部アクセス ***/
    // 寿命
    public float m_lifeSecond = 1.0f;

    // ラインの長さ
    public Vector3 m_endPosition;
    public Vector3 m_addForce;

    // ラインの幅
    public AnimationCurve m_lineWidthCarve;

    /*** メンバ変数 ***/
    private LineRenderer m_lineRenderer;
    private ParticleSystem m_particleSystem;
    private float m_lenght;
    private float m_lifeSecondCount;
    private float m_lineCarveTime;

    /*** 定数 ***/
    private const int LINE_START = 0;
    private const int LINE_END = 1;

    ///--------------------------------------------------------------
    /// <summary>
    /// 開始処理
    /// </summary>
    ///--------------------------------------------------------------
	void Awake () 
    {
        float startWidth = m_lineWidthCarve.Evaluate(0.0f);

        m_lenght = 0.0f;
        m_lineRenderer = this.GetComponent<LineRenderer>();
        m_particleSystem = this.GetComponent<ParticleSystem>();
        m_lineRenderer.SetPosition(LINE_START, transform.position);
        m_lineRenderer.SetWidth(startWidth, startWidth);

        m_lifeSecond = m_particleSystem.duration;

        // コルーチンを開始
        StartCoroutine(LifeCount());    // 寿命の計算
        StartCoroutine(BeamFire());     // ビーム発射処理
        StartCoroutine(LineWidth());    // ビームの幅の処理
	}

    ///--------------------------------------------------------------
    /// <summary>
    /// ビームが伸びる処理
    /// </summary>
    /// <returns></returns>
    ///--------------------------------------------------------------
    private IEnumerator BeamFire()
    {
        // ループ
        while(true)
        {
            // ラインの最終地点を更新
            m_endPosition += m_addForce;

            // ラインのスタートとエンドを決める
            m_lineRenderer.SetPosition(LINE_START, transform.position);
            m_lineRenderer.SetPosition(LINE_END, transform.position + m_endPosition);
            yield return null;
        }
    }

    ///--------------------------------------------------------------
    /// <summary>
    /// 寿命のカウント処理
    /// </summary>
    /// <returns></returns>
    ///--------------------------------------------------------------
    private IEnumerator LifeCount()
    {
        // カウントが寿命を超えるまでループする
        while( m_lifeSecondCount < m_lifeSecond )
        {
            // 寿命カウントを増やす
            m_lifeSecondCount += Time.deltaTime;

            // 寿命の比較値を出す
            float life = m_lifeSecondCount / m_lifeSecond;
            yield return null;
        }

        m_particleSystem.Stop();

        while( m_particleSystem.isPlaying == true )
        {
            yield return null;
        }

        // 寿命が尽きたら削除する
        Destroy(gameObject);
    }

    ///--------------------------------------------------------------
    /// <summary>
    /// ビームの幅の処理
    /// </summary>
    /// <returns></returns>
    ///--------------------------------------------------------------
    private IEnumerator LineWidth()
    {
        while( true )
        {
            float life = m_lifeSecondCount / m_lifeSecond;
            float width = m_lineWidthCarve.Evaluate(life);
            m_lineRenderer.SetWidth(width, width);
            yield return null;
        }
    }
}
