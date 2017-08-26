using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 仮スコア
/// 有冨勇帆
/// </summary>
public class AritomiScore : MonoBehaviour
{
    Text m_textScore;
    int m_iScore;
    [SerializeField]
    int[] m_bonus = null;
    int m_comboCount;

    public void AddScore(int num)
    {


        UpdateText();
    }

    public void ResetScore()
    {
        UpdateText();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Awake()
    {
        m_textScore = GetComponent<Text>();
    }

    /// <summary>
    /// 開始
    /// </summary>
    void Start()
    {
        m_iScore = 0;
        UpdateText();
    }

    public void ResetCount()
    {
        m_comboCount = 0;
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {

    }

    private void UpdateText()
    {
        m_textScore.text = m_iScore.ToString();
    }
}
