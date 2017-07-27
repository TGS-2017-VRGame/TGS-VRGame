using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ポールマネージャー
/// 有冨
/// </summary>
public class PoleManager : MonoBehaviour
{
    private enum PoleType
    {
        KAMATO = 0,
        PATTI,
        GOLDEN_KAMATO,
        GOLDEN_PATTI,
    }
    [SerializeField]
    private SpawnPole[] m_setSpawnPoints = null;   //! スポーン位置セット用

    private List<List<SpawnPole>> m_spawnPoints = null;//!実際に管理している二次元配列

    [SerializeField]
    private GameObject[] m_objectPoles = null;  //! ポールオブジェクト
    [SerializeField]
    private float m_fActiveTime = 1f;   //! 出現するインターバル
    [SerializeField]
    private int m_rang = 10;

    private AnimManager m_anim;

    private AritomiTimer m_timerActive;

    /// <summary>
    /// 二次元配列っぽく扱う
    /// </summary>
    /// <param name="_x"></param>
    /// <param name="_y"></param>
    /// <param name="_size"></param>
    /// <returns></returns>
    //private SpawnPole SpawnPole(int _x, int _y, int _size)
    //{
    //    int index = _y + _x * _size;

    //    return m_spawnPoints[index];
    //}

    private void Awake()
    {
        m_timerActive = new AritomiTimer(m_fActiveTime);
    }

    /// <summary>
    /// 開始
    /// </summary>
    void Start()
    {
        m_anim = new AnimManager();
        m_anim.AddAnimMethod((int)GAME_SCENE_TYPE.GAME_PLAY, GamePlay);
        m_timerActive.Reset();

        SetSpawnPoint();
    }

    void SetSpawnPoint()
    {
        m_spawnPoints = new List<List<global::SpawnPole>>();
        var length = 3;
        for (var y = 0; y < length; y++)
        {
            var list = new List<SpawnPole>();
            for (var x = 0; x < length; x++)
            {
                list.Add(m_setSpawnPoints[x + y]);
            }
            m_spawnPoints.Add(list);
        }
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
        int index_X = Random.Range(0, 3);
        int index_Y = Random.Range(0, 3);

        int indexObjectPole = Random.Range(0, m_objectPoles.Length);
        var point = m_spawnPoints[index_X][index_Y];
        if (point.HasPole())
        {
            point.Create(m_objectPoles[indexObjectPole]);
        }
        m_timerActive.Reset();
    }
}
