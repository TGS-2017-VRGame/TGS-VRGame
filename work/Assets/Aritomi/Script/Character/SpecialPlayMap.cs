using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 左から右に移動
/// </summary>
public class SpecialPlayMap : MonoBehaviour
{
    [SerializeField]
    private float m_moveTime = 1;

    private Transform m_start = null;
    private Transform m_end = null;

    private float m_time;

    /// <summary>
    /// 開始
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="_start"></param>
    /// <param name="_end"></param>
    public void Init(Transform _start, Transform _end)
    {
        m_start = _start;
        m_end = _end;
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        Move();
    }

    private void Move()
    {
        m_time += Time.deltaTime;

        float t = m_time / m_moveTime;

        t = Mathf.Min(1, t);

        Vector3 start = m_start.position;
        Vector3 end = m_end.position;

        transform.position = Vector3.Lerp(start, end, t);

        if (t >= 1)
        {
            Destroy(gameObject);
        }
    }

}
