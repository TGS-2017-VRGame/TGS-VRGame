using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> m_spawnPoints = null;
    [SerializeField]
    private List<GameObject> m_objectPoles = null;
    [SerializeField]
    private float m_fActiveTime = 1f;

    private GameObject[] m_poles = null;

    private AritomiTimer m_timerActive;

    private void Awake()
    {
        m_timerActive = new AritomiTimer(m_fActiveTime);
        m_poles = new GameObject[m_spawnPoints.Count];
    }

    /// <summary>
    /// 開始
    /// </summary>
    void Start()
    {
        m_timerActive.Reset();
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        m_timerActive.Update(Time.deltaTime);

        if (m_timerActive.IsTimeOver())
        {
            int indexSpawnPoint = Random.Range(0, m_spawnPoints.Count);
            int indexObjectPole = Random.Range(0, m_objectPoles.Count);

            if (m_poles[indexSpawnPoint] == null)
            {
                m_poles[indexSpawnPoint] = (GameObject)Instantiate(m_objectPoles[indexObjectPole], m_spawnPoints[indexSpawnPoint].position, Quaternion.identity);
                m_poles[indexSpawnPoint].transform.SetParent(transform);
            }
            m_timerActive.Reset();
        }
    }
}
