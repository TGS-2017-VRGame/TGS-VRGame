using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleAnim : MonoBehaviour
{
    [SerializeField]
    private float m_lowPosition = 0.6f;     //! 下
    [SerializeField]
    private float m_highPosition = 0f;	    //! 上
    [SerializeField]
    private float m_fUpTime = 1f;   //! 上がる時間
    [SerializeField]
    private float m_fDownTime = 1f; //! 下がる時間
    [SerializeField]
    private float m_fWaitTime = 1f; //! 待機時間
    [SerializeField]
    private bool m_isAnimation = true;

    private Vector3 m_startPosition;

    private bool m_isActive;

    private AritomiTimer m_timerWait;      //! 待機時間

    private float m_time;

    /// <summary>
    /// アニメーションステップ
    /// </summary>
    private enum AnimStep
    {
        ANIM_UPPER,
        ANIM_WAIT,
        ANIM_DOWN,
    }

    private AnimStep m_animStep;    //! アニメーションステップ
    delegate void AnimMethod();     //! アニメーション関数
    private Dictionary<AnimStep, AnimMethod> m_animMethods =  //! アニメーション関数コンテナ
        new Dictionary<AnimStep, AnimMethod>();

    /// <summary>
    /// 初期化
    /// </summary>
    private void Awake()
    {
        m_timerWait = new AritomiTimer(m_fWaitTime);

        m_animMethods.Add(AnimStep.ANIM_DOWN, AnimDown);
        m_animMethods.Add(AnimStep.ANIM_UPPER, AnimUp);
        m_animMethods.Add(AnimStep.ANIM_WAIT, AnimWait);
    }

    // Use this for initialization
    void Start()
    {
        m_isActive = true;
        m_timerWait.Reset();
        m_animStep = AnimStep.ANIM_UPPER;

        m_time = 0;

        m_startPosition = transform.position;

        transform.position = m_startPosition + new Vector3(0, m_lowPosition, 0);

    }

    // Update is called once per frame
    void Update()
    {
        bool isActive = m_isAnimation && m_isActive;
        if (isActive)
        {
            m_animMethods[m_animStep]();
        }
    }

    /// <summary>
    /// アクティブにする
    /// </summary>
    public void Active()
    {
        if (m_isActive)
        {
            return;
        }

        m_isActive = true;
    }

    private void AnimUp()
    {
        Vector3 start = m_startPosition + new Vector3(0, m_lowPosition, 0);
        Vector3 end = m_startPosition + new Vector3(0, m_highPosition, 0);

        m_time += Time.deltaTime;

        float t = m_time / m_fUpTime;
        t = Mathf.Min(t, 1);

        transform.position = Vector3.Lerp(start, end, t);

        if (t >= 1)
        {
            m_animStep = AnimStep.ANIM_WAIT;
            m_time = 0;
        }
    }

    private void AnimDown()
    {
        Vector3 start = m_startPosition + new Vector3(0, m_highPosition, 0);
        Vector3 end = m_startPosition + new Vector3(0, m_lowPosition, 0);

        m_time += Time.deltaTime;

        float t = m_time / m_fDownTime;
        t = Mathf.Min(t, 1);

        transform.position = Vector3.Lerp(start, end, t);

        if (t >= 1)
        {
            m_animStep = AnimStep.ANIM_UPPER;
            Destroy(gameObject);
        }
    }

    private void AnimWait()
    {
        m_timerWait.Update(Time.deltaTime);

        if (m_timerWait.IsTimeOver())
        {
            m_animStep = AnimStep.ANIM_DOWN;
            m_timerWait.Reset();
        }
    }
}
