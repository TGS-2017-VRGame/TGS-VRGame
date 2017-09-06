using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text m_text;          //! スコアのテキスト
    [SerializeField]
    private Slider m_slider;      //! スライダー
    private int m_iScore;               //! スコアの数値
    [SerializeField]
    int[] m_bonus = null;       //! コンボボーナス
    int m_comboCount;           //! コンボカウント
    AritomiTimer m_timer;              //! タイマー
    [SerializeField]
    float m_comboOverTime;      //! コンボが途切れるまでの時間


    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        m_iScore = 0;
        m_timer = new AritomiTimer(0);
        m_timer.Start();
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        m_timer.Update(Time.deltaTime);

        if (m_timer.IsTimeOver())
        {
            ResetCount();
        }

        if (m_slider)
        {
            m_slider.value = m_timer.GetT();
        }
    }

    /// <summary>
    /// スコアの加算
    /// </summary>
    /// <param name="_point">加算したい値(指定がなければ１加算)</param>
    public int Add(int _point = 1)
    {
        int point = _point + m_bonus[m_comboCount];
        m_iScore += _point + m_bonus[m_comboCount];
        m_comboCount = Mathf.Clamp(m_comboCount + 1, 0, m_bonus.Length - 1);

        ToText();

        m_timer.SetTime(m_comboOverTime);

        return point;
    }

    /// <summary>
    /// スコアをString型に変換してテキストに入れる
    /// </summary>
    void ToText()
    {
        if (!m_text)
        {
            return;
        }
        m_text.text = m_iScore.ToString();
    }

    /// <summary>
    /// スコアの再設定
    /// </summary>
    public void Reset()
    {
        m_iScore = 0;
        m_comboCount = 0;
        ToText();
    }

    /// <summary>
    /// コンボカウントをリセットする
    /// </summary>
    public void ResetCount()
    {
        m_comboCount = 0;
    }

    /// <summary>
    /// スコアが同じか？
    /// </summary>
    /// <returns></returns>
    public bool IsSameScore(int _score)
    {
        return m_iScore == _score;
    }
}
