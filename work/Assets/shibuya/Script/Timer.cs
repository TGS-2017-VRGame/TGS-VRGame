using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float time;         //タイマーの時間
    [SerializeField]
    private Text text;         //タイマーテキスト
    private float defaultTime;  //インスペクタで設定した値
    public bool IsStop { set; get; }//一時停止用のフラグ

    private Action callback;

    /// <summary>
    /// 呼び出す関数を設定
    /// </summary>
    /// <param name="_action"></param>
    public void SetAction(Action _action)
    {
        callback = _action;
    }
    // Use this for initialization
    void Start()
    {
        defaultTime = time;
        IsStop = false;
        // Aritomi Add
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        CallBack();
    }

    /// <summary>
    /// タイマーの再設定
    /// </summary>
    /// <param name="_time"></param>
    public void SetTime(float _time)
    {
        time = _time;
        defaultTime = time;
    }

    /// <summary>
    /// インスペクタで設定した時間に戻す
    /// </summary>
    public void ResetTime()
    {
        time = defaultTime;
    }

    /// <summary>
    /// 時間切れかどうか
    /// </summary>
    /// <returns>時間切れだったらtrue、時間内ならfalse</returns>
    public bool IsEnd()
    {
        return time <= 0;
    }

    /// <summary>
    /// タイマーの更新
    /// </summary>
    void UpdateTimer()
    {
        if (IsStop) return;

        time = Mathf.Clamp(time - Time.deltaTime, 0, defaultTime);
        text.text = time.ToString("N1");
    }

    /// <summary>
    /// 時間延長
    /// </summary>
    /// <param name="_value">延長する時間</param>
    public void AddTime(int _value)
    {
        time += _value;
    }

    /// <summary>
    /// タイマーが０になったら関数を呼び出す
    /// </summary>
    private void CallBack()
    {
        if (callback == null)
        {
            return;
        }
        if (IsEnd())
        {
            callback();
        }
    }
}
