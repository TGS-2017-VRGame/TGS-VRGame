using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ポール
/// </summary>
public class Pole : MonoBehaviour
{
    public int AddScore {get; set;}                     //! 追加するスコア
    [SerializeField]
    protected GameObject m_getScoreObject = null;       //! 獲得スコアエフェクト
    [SerializeField]
    protected int m_addScore = 10;                      //! スコア
    [SerializeField]
    protected int m_iLevel = 0;                         //! レベル
    [SerializeField]
    protected float m_scoreRotOffset = 0;               //! 獲得スコアエフェクトの回転オフセット

    protected Score m_score;                     //! スコア

    /// <summary>
    /// 開始
    /// </summary>
    void Start()
    {
        m_score = GameObject.Find("Score").GetComponent<Score>();
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
    }

    /// <summary>
    /// 衝突判定
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Lasso"))
        {
            return;
        }

        UniqeHitLasso();

        PlayVibration();
    }

    /// <summary>
    /// バイブレーションを再生
    /// </summary>
    private void PlayVibration()
    {
        byte[] samples = new byte[8];

        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = 255;
        }

        Destroy(GetComponent<Collider>());

        OVRHapticsClip hapticsClip = new OVRHapticsClip(samples, samples.Length);
        OVRHaptics.LeftChannel.Mix(hapticsClip);
        OVRHaptics.RightChannel.Mix(hapticsClip);
    }

    /// <summary>
    /// 輪っかに当たった時の処理
    /// </summary>
    protected virtual void UniqeHitLasso()
    {
        SEManager.main.PlayOneShot("pointget");
        int point = m_score.Add(m_addScore);

        CreateGetScoreObject(point);

        Destroy(gameObject, 1);
    }

    protected void CreateGetScoreObject(int _point)
    {
        if (HasGetScore(m_getScoreObject))
        {
            GetScore getScore =
                Instantiate(
                    m_getScoreObject,
                    transform.position,
                    transform.rotation * Quaternion.Euler(0, m_scoreRotOffset, 0)).GetComponent<GetScore>();

            getScore.SetScore(_point);
        }
    }

    /// <summary>
    /// ゲットスコアを持っているか？
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    protected bool HasGetScore(GameObject obj)
    {
        return obj.GetComponent<GetScore>();
    }
}
