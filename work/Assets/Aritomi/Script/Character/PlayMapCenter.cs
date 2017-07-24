using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイマップたちを回転させるだけ
/// </summary>
public class PlayMapCenter : MonoBehaviour
{
    [SerializeField]
    private float m_roatePower = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation *= Quaternion.Euler(0, m_roatePower, 0);
    }
}
