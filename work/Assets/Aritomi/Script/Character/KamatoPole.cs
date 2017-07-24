using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// かまとぅポール
/// でたり引っ込んだり
/// </summary>
public class KamatoPole : MonoBehaviour
{
    [SerializeField]
    private GameObject m_getScoreObject = null;      //! 
    [SerializeField]
    private int m_addScore = 10;          //! スコア
    [SerializeField]
    private int m_iLevel = 0;       //! レベル
    [SerializeField]
    private float m_scoreRotOffset = 0;  //!
    private AritomiScore m_score;

    public void SetScore(AritomiScore score)
    {
        m_score = score;
    }

    /// <summary>
    /// 開始
    /// </summary>
    void Start()
    {

        m_score = GameObject.Find("Score").GetComponent<AritomiScore>();
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Lasso"))
        {
            return;
        }

        m_score.AddScore(m_addScore);


        if (HasGetScore(m_getScoreObject))
        {
            GetScore getScore = 
                Instantiate(
                    m_getScoreObject, 
                    transform.position,
                    transform.rotation * Quaternion.Euler(0, m_scoreRotOffset, 0)).GetComponent<GetScore>();

            getScore.SetScore(m_addScore);
        }

        Destroy(gameObject);
    }

    /// <summary>
    /// ゲットスコアを持っているか？
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private bool HasGetScore(GameObject obj)
    {
        GetScore instance = obj.GetComponent<GetScore>();

        if (instance)
        {
            return true;
        }

        return false;
    }
}
