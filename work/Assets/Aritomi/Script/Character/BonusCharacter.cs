using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボーナスかまとぅ
/// Aritomi
/// </summary>
public class BonusCharacter : MonoBehaviour
{
    [SerializeField]
    private float m_spawnTime;          //! 出現時間
    [SerializeField]   
    private float m_waitTime;           //! 出現後の待機時間

    [SerializeField]
    private string m_animwait;
    [SerializeField]
    private string m_animshow;
    [SerializeField]
    private string m_animhide;

    private Animator m_animator;        //! アニメーションコントローラー

    private AritomiTimer m_waitTimer;   //! 出現後の待機時間タイマー

    private AnimManager m_animManager;  //! アニメーションマネージャー

    private bool m_isActive;

    /// <summary>
    /// アニメーションステップ
    /// </summary>
    private enum AnimStep
    {
        START,
        SPAWN,
        END
    }
    private AnimStep m_step;            //! アニメーションステップ

    /// <summary>
    /// 初期化
    /// </summary>
    private void Awake()
    {
        m_waitTimer = new AritomiTimer(m_waitTime);
        m_animManager = new AnimManager();

        m_step = AnimStep.START;

        m_animManager.AddAnimMethod((int)AnimStep.START, AnimStart);
        m_animManager.AddAnimMethod((int)AnimStep.SPAWN, AnimSpawn);
        m_animManager.AddAnimMethod((int)AnimStep.END, AnimEnd);

        m_animator = GetComponent<Animator>();

        m_isActive = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            IsActive();
        }

        m_animManager.GetAnimMethod((int)m_step);
    }

    public void IsActive()
    {
        // アクティブ状態なら何もしない
        if (m_isActive)
        {
            return;
        }

        m_isActive = false;

        m_animator.Play(m_animshow);
        m_step = AnimStep.SPAWN;
    }

    /// <summary>
    /// アニメーション開始
    /// </summary>
    private void AnimStart()
    {
        m_animator.Play(m_animwait);
    }

    /// <summary>
    /// アニメーション召喚
    /// </summary>
    private void AnimSpawn()
    {
        m_waitTimer.Update(Time.deltaTime);

        if (m_waitTimer.IsTimeOver())
        {
            m_step = AnimStep.END;

            m_animator.Play(m_animhide);

            m_step = AnimStep.END;
        }
    }

    /// <summary>
    /// アニメーション終了
    /// </summary>
    private void AnimEnd()
    {
    }

    /// <summary>
    /// アニメーション終了処理
    /// </summary>
    public void EndAnimation()
    {
        m_step = AnimStep.START;

        m_isActive = false;
    }
}
