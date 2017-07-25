using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ポールマネージャー
/// 有冨
/// </summary>
public class PoleManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> m_spawnPoints = null;
    [SerializeField]
    private List<GameObject> m_objectPoles = null;
    [SerializeField]
    private List<GameObject> m_objectGoldenPoles = null;
    [SerializeField]
    private float m_fActiveTime = 1f;
    [SerializeField]
    private int m_rang = 10;
    
    private AnimManager m_anim;

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
        m_anim = new AnimManager();
        m_anim.AddAnimMethod((int)GAME_SCENE_TYPE.GAME_PLAY, GamePlay);
        m_timerActive.Reset();
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        m_anim.GetAnimMethod((int)GameManager.main.currentGameType);
    }

    private void GamePlay()
    {
        m_timerActive.Update(Time.deltaTime);

        if (m_timerActive.IsTimeOver())
        {
            CreatePole();
        }
    }

    private void CreatePole()
    {
        int rnd = Random.Range(0, m_rang + 1);

        if (rnd % 5 == 0)
        {
            CreateGoldenPole();
            return;
        }

        CreateNormalPole();
    }

    private void CreateNormalPole()
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

    private void CreateGoldenPole()
    {
        int indexSpawnPoint = Random.Range(0, m_spawnPoints.Count);
        int indexObjectPole = Random.Range(0, m_objectGoldenPoles.Count);

        if (m_poles[indexSpawnPoint] == null)
        {
            m_poles[indexSpawnPoint] = (GameObject)Instantiate(m_objectGoldenPoles[indexObjectPole], m_spawnPoints[indexSpawnPoint].position, Quaternion.identity);
            m_poles[indexSpawnPoint].transform.SetParent(transform);
        }
        m_timerActive.Reset();
    }
}
