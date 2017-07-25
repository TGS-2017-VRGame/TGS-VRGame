using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// かまとぅポール
/// でたり引っ込んだり
/// </summary>
public class Pole : MonoBehaviour
{
    [SerializeField]
    protected GameObject m_getScoreObject = null;      //! 
    [SerializeField]
    protected int m_addScore = 10;          //! スコア
    [SerializeField]
    protected int m_iLevel = 0;       //! レベル
    [SerializeField]
    protected float m_scoreRotOffset = 0;  //!
    protected AritomiScore m_score;

    private AudioSource m_audio;

    public void SetScore(AritomiScore score)
    {
        m_score = score;
    }

    /// <summary>
    /// 開始
    /// </summary>
    void Start()
    {
        m_audio = GetComponent<AudioSource>();
        m_score = GameObject.Find("Score").GetComponent<AritomiScore>();
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            m_audio.PlayOneShot(m_audio.clip);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Lasso"))
        {
            UniqeHitLasso();
        }
    }

    /// <summary>
    /// 輪っかに当たった時の処理
    /// </summary>
    protected virtual void UniqeHitLasso()
    {
        SEManager.main.PlayOneShot("pointget");
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
    protected bool HasGetScore(GameObject obj)
    {
        GetScore instance = obj.GetComponent<GetScore>();

        if (instance)
        {
            return true;
        }

        return false;
    }
}
