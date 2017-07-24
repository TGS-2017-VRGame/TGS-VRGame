using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private int scorePoint;     //スコア
    [SerializeField]
    private Text text;         //スコアのテキスト

	// Use this for initialization
	void Start () {
        scorePoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
    }

    /// <summary>
    /// スコアの加算
    /// </summary>
    /// <param name="_point">加算したい値(指定がなければ１加算)</param>
    public void Add(int _point = 1)
    {
        scorePoint += _point;
        ToText();
    }

    /// <summary>
    /// スコアをString型に変換してテキストに入れる
    /// </summary>
    void ToText()
    {
        text.text = scorePoint.ToString();
    }

    /// <summary>
    /// スコアの再設定
    /// </summary>
    public void Reset()
    {
        scorePoint = 0;
        ToText();
    }
}
