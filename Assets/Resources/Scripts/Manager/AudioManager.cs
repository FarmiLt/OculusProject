using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AudioManager : SingletonMonoBehaviour<AudioManager> {
      

    // メンバ変数
    public AudioSource       m_bgmSource;   // BGM音源
    public List<AudioClip>   m_bgmList;     // BGMリスト
    public List<AudioClip>   m_seList;      // SEリスト


    /**************************************************************************
     * シーン読み込み時処理
	 **************************************************************************/
    void Awake()
    {
        // 既にある場合は自身を削除
        if (this != Instance)
        {
            Destroy(this.gameObject);
            return;
        }

        // このオブジェクトを破棄されないオブジェクトにする
        DontDestroyOnLoad(this);

		Initialize ();
    }


	/**************************************************************************
     * 初期化処理
	 **************************************************************************/
	public void Initialize () {
        m_bgmSource = this.transform.FindChild("BGMPlayer").GetComponent<AudioSource>();
	}


    /**************************************************************************
     * ＢＧＭの読み込み処理
     * 
     * 引数１ : テキストファイルパス(Resources内の)
     **************************************************************************/
    public void LoadBGMs(string fileName) {
        LoadFileData(m_bgmList, fileName);
		Debug.Log ("BGM Load Finish.");
    }


    /**************************************************************************
     * ＳＥの読み込み処理
     * 
     * 引数１ : テキストファイルパス(Resources内の)
	 **************************************************************************/
    public void LoadSEs(string fileName) {
        LoadFileData(m_seList, fileName);
        Debug.Log("SE Load Finish.");
    }


    /**************************************************************************
     * ファイルデータ読み込み処理
     * 
     * 引数１ : 書き込むリスト
     * 引数２ : 読み込むテキストファイル
	 **************************************************************************/
    private void LoadFileData(List<AudioClip> dataList, string fileName)
    {
        // 古いデータは削除
        dataList.Clear();

        // テキストファイルの読み込み
        TextAsset textAsset = Resources.Load(fileName) as TextAsset;
        string[] datas = textAsset.text.Replace("\r\n", "\n").Split('\n');

        foreach (string soundFile in datas)
        {
            // BGM登録
            dataList.Add(Resources.Load(soundFile) as AudioClip);
        }
    }



    /**************************************************************************
     * ＢＧＭ再生処理
     * 
     * 引数１ : インデックス
	 **************************************************************************/
    public void PlayBGM(int index) {
        if (index < 0) Debug.LogError("Incorrect BGM index!");
        if (m_bgmList.Count <= index) Debug.LogError("Access out of BGM collection!");

        m_bgmSource.clip = m_bgmList[index];
        
        m_bgmSource.Play();
    }


    /**************************************************************************
     * ＳＥ再生処理
     * 
     * 引数１ : インデックス
     * 引数２ : 再生する音源
	 **************************************************************************/
    public void PlaySE(int index, AudioSource seSource)
    {
		bool isOK = true;

		if ( seSource == null ){
			// 渡された音源が正しくないよ！
			Debug.LogError ("Incorrect AudioSource!");
			return;
		}

        if (index < 0) {
			Debug.LogError("Incorrect SE index!");
			return;
		}
        if (m_seList.Count <= index){
			Debug.LogError("Access out of SE collection!");
			return;
		}

        seSource.clip = m_seList[index];
        seSource.Play();
    }
}
