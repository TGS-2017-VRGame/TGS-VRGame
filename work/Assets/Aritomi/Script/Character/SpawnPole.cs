using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPole : MonoBehaviour
{
    private GameObject m_currentPole = null;

    public bool IsActive { get; set; }

    /// <summary>
    /// 初期化
    /// </summary>
    void Awake()
    {
        IsActive = true;
        m_currentPole = null;
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// 生成
    /// </summary>
    /// <param name="_pole"></param>
    public void Create(GameObject _pole)
    {
        if (IsActive)
        {
            m_currentPole = Instantiate(_pole, transform.position, Quaternion.identity);
        }
    }

    /// <summary>
    /// ポールを持ってるか？
    /// </summary>
    /// <returns></returns>
    public bool HasPole()
    {
        return !m_currentPole;
    }
}
