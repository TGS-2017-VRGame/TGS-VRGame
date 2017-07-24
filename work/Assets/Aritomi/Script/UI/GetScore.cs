using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    [SerializeField]
    private float m_up;
    [SerializeField]
    private float m_animTime;

    private float m_time;

    private int m_score;  //! スコア

    private Vector3 m_startPosition;
    private Vector3 m_endPosition;

    /// <summary>
    /// 開始
    /// </summary>
    private void Start()
    {
        m_score = 0;
        m_time = 0;

        Init();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Init()
    {
        m_startPosition = transform.position;
        m_endPosition = m_startPosition;
        m_endPosition.y += m_up;
    }

    /// <summary>
    /// 更新
    /// </summary>
    private void Update()
    {
        m_time += Time.deltaTime;

        m_time = Mathf.Min(m_time, m_animTime);
        m_time = Mathf.Max(m_time, 0);
        Move();
    }

    /// <summary>
    /// スコアを設定
    /// </summary>
    /// <param name="_score">スコア</param>
    public void SetScore(int _score)
    {
        m_score = _score;

        TextMesh text = GetComponent<TextMesh>();

        text.text = _score.ToString();
    }

    /// <summary>
    /// 移動
    /// </summary>
    void Move()
    {
        float t = m_time / m_animTime;

        transform.position = Vector3.Lerp(m_startPosition, m_endPosition, t);

        if (t == 1)
        {
            Destroy(gameObject, 1);
        }
    }
}
