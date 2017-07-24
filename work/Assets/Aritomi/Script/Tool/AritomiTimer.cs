using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// タイマークラス
/// 有冨勇帆
/// </summary>
public class AritomiTimer
{
    private float m_time;       //! 時間
    private float m_setTime;    //! セット時間保管用変数
    private bool m_isStop;      //! タイマーが止まっているか？

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public AritomiTimer(float time)
    {
        m_setTime = time;
        m_time = m_setTime;
        m_isStop = false;
    }

    /// <summary>
    /// 時間を進める
    /// </summary>
    /// <param name="deltaTime"></param>
    public void Update(float deltaTime)
    {
        if (m_isStop == true || IsTimeOver())
        {
            return;
        }

        m_time -= deltaTime;

        m_time = Mathf.Max(0, m_time);
    }

    /// <summary>
    /// 時間を指定
    /// タイマーはリセットされる
    /// </summary>
    /// <param name="setTime"></param>
    public void SetTime(float setTime)
    {
        m_setTime = setTime;
        m_time = m_setTime;

        Reset();
    }

    /// <summary>
    /// タイマーを動かす
    /// </summary>
    public void Start()
    {
        m_isStop = false;
    }

    /// <summary>
    /// タイマーを止める
    /// </summary>
    public void Stop()
    {
        m_isStop = true;
    }

    /// <summary>
    /// 時間をリセット
    /// </summary>
    public void Reset()
    {
        m_time = m_setTime;
    }

    /// <summary>
    /// 時間切れか？
    /// </summary>
    /// <returns></returns>
    public bool IsTimeOver()
    {
        return m_time <= 0;
    }

    /// <summary>
    /// 現在の時間を取得する
    /// </summary>
    /// <returns></returns>
    public float GetTime()
    {
        return m_time;
    }

    /// <summary>
    /// 情報を文字列で返す
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return "m_time : " + m_time;
    }
}
