using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// フラグアシスタント
/// Aritomi
/// </summary>
public class FlagAssistant : MonoBehaviour
{
    public static FlagAssistant main;   //! シングルトン

    /// <summary>
    /// ラッシュモードか？
    /// </summary>
    public bool IsRushMode { get; set; }

    /// <summary>
    /// 開始か？
    /// </summary>
    public bool IsStart { get; set; }

    private void Awake()
    {
        main = this;
    }

    /// <summary>
    /// 開始
    /// </summary>
    private void Start()
    {
        IsRushMode = false;
        IsStart = false;
    }
}
