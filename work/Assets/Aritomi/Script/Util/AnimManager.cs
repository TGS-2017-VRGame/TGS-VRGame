using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アニメーションマネージャー
/// </summary>
public class AnimManager
{
    public delegate void Method();

    Dictionary<int, Method> m_anims = new Dictionary<int, Method>();

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public AnimManager()
    {

    }

    /// <summary>
    /// アニメーションを追加
    /// </summary>
    /// <param name="_key"></param>
    /// <param name="_animMethod"></param>
    public void AddAnimMethod(int _key, Method _animMethod)
    {
        m_anims.Add(_key, _animMethod);
    }

    /// <summary>
    /// アニメーションを取得する
    /// </summary>
    /// <param name="_key"></param>
    public void GetAnimMethod(int _key)
    {
        if (!m_anims.ContainsKey(_key))
        {
            return;
        }

        m_anims[_key]();
    }
}
