using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlayMapManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_specialMap = null;    //! スペシャルマップ
    [SerializeField]
    private Transform m_start = null;          //! 開始位置
    [SerializeField]
    private Transform m_end = null;            //! 終了位置
    [SerializeField]
    private float m_spawnTime = 5;              //! スポーン時間

    private AritomiTimer m_spawnTimer;

    // Use this for initialization
    void Start()
    {
        m_spawnTimer = new AritomiTimer(m_spawnTime);
        m_spawnTimer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTimer.Update(Time.deltaTime);

        if (m_spawnTimer.IsTimeOver())
        {
            SpecialPlayMap specialPlayMap = Instantiate(m_specialMap).GetComponent<SpecialPlayMap>();
            specialPlayMap.Init(m_start, m_end);
            m_spawnTimer.Reset();
        }
    }
}
