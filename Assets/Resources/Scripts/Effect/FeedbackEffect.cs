using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FeedbackEffect : MonoBehaviour
{
    /// <summary>
    /// ブラーのブレンド率
    /// </summary>
    [Range(0.0f, 1.0f)]
    public float blend = 0.1f;
    /// <summary>
    /// ポストエフェクト用のシェーダ
    /// </summary>
    public Shader shader;
    /// <summary>
    /// 中心
    /// </summary>
    public Vector4 center = new Vector4(0.5f, 0.5f, 0.0f, 0.0f);
    float _aspect = 1.0f;

    float _alpha;
    [SerializeField]
    float _scale = 1.0f;
    [SerializeField]
    float _rotation = 0.0f;

    RenderTexture accumTexture;

    int _MainTexID;
    int _BlendID;
    int _RotateID;
    int _CenterID;

    Material material;

    void Awake()
    {
        _MainTexID = Shader.PropertyToID("_MainTex");
        _BlendID = Shader.PropertyToID("_Blend");
        _RotateID = Shader.PropertyToID("_Rotate");
        _CenterID = Shader.PropertyToID("_Center");
    }

    void OnEnable()
    {
        material = new Material(shader);
        material.hideFlags = HideFlags.HideAndDontSave;
    }

    protected void OnDisable()
    {
        if (accumTexture != null) DestroyImmediate(accumTexture);
        if (material != null) DestroyImmediate(material);
        accumTexture = null;
        material = null;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (accumTexture == null)
        {
            if (accumTexture == null)
            {
                DestroyImmediate(accumTexture);
            }
            accumTexture = null;
            accumTexture = new RenderTexture(source.width / 2, source.height / 2, 0);
            accumTexture.hideFlags = HideFlags.HideAndDontSave;
            Graphics.Blit(source, accumTexture);
        }

        material.SetTexture(_MainTexID, accumTexture);
        material.SetFloat(_BlendID, blend);
        float c = Mathf.Cos(_rotation) * _scale;
        float s = Mathf.Sin(_rotation) * _scale;
        material.SetVector(_RotateID, new Vector4(c, -s / _aspect, s, c / _aspect));
        material.SetVector(_CenterID, center);

        accumTexture.MarkRestoreExpected();

        Graphics.Blit(accumTexture, source, material);
        Graphics.Blit(source, accumTexture);
        Graphics.Blit(source, destination);
    }
}