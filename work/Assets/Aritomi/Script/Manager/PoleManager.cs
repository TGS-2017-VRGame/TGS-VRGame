using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
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
    private List<List<SpawnPole>> m_spawns = null;   //! スポーン位置
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
        m_spawns = new List<List<SpawnPole>>();
    }

    /// <summary>
    /// 開始
    /// </summary>
    void Start()
    {
        m_anim = new AnimManager();
        m_anim.AddAnimMethod((int)GAME_SCENE_TYPE.GAME_PLAY, GamePlay);
        m_timerActive.Reset();

        var child = transform.GetComponentsInChildren<SpawnPole>().ToList();
        child.Sort(NameNumberCompare);
        for (int y = 0; y < 3; y++)
        {
            var list = new List<SpawnPole>();
            for (int x = 0; x < 3; x++)
            {
                list.Add(child[x]);
            }
            m_spawns.Add(list);
        }

    }

    /*
    SpawnPoleのオブジェクト名の最後が数字なのでその数字を使いソート
    */
    int NameNumberCompare(SpawnPole _a,SpawnPole _b)
    {
        return _a.name.LastOrDefault() - _b.name.LastOrDefault();
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
        var point = m_spawns[index_X][index_Y];
        if (point.HasPole())
        {
            point.Create(m_objectPoles[indexObjectPole]);
        }
        m_timerActive.Reset();
    }
}
