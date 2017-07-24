using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 仮スコア
/// 有冨勇帆
/// </summary>
namespace Aritomi
{
    public class Score : MonoBehaviour
    {
        Text m_textScore;
        int m_iScore;

        public void AddScore(int num)
        {
            m_iScore += num;
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
}
