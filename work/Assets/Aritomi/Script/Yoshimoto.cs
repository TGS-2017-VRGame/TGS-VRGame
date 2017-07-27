using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Oculus Tocuh の振動テスト
/// </summary>
public class Yoshimoto : MonoBehaviour
{
    [SerializeField]
    public AudioClip 音データ;
    public OVRHapticsClip バイブレーション;

    // Use this for initialization
    void Start()
    {
        バイブレーション = new OVRHapticsClip(音データ);
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger))
        {
            OVRHaptics.LeftChannel.Mix(バイブレーション);
            OVRHaptics.RightChannel.Mix(バイブレーション);
        }

    }
}
