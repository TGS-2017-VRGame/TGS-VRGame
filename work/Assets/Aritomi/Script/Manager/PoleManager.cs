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
    private List<SpawnList> m_spawns = new List<SpawnList>();   //! スポーン位置
    [SerializeField]
    private List<SpanData> m_spanDatas = new List<SpanData>();
    [SerializeField]
    private GameObject[] m_objectPoles = null;  //! ポールオブジェクト
    [SerializeField]
    private float m_fActiveTime = 1f;   //! 出現するインターバル
    [SerializeField]
    private float m_fRushTime = 5f;     //! ラッシュ時間
    [SerializeField]
    private int m_rang = 10;

    private int[,] m_score = new int[3, 3]
    {
        { 50, 50, 50 },
        { 30, 30, 30 },
        { 10, 10, 10 }
    };

    private AnimManager m_anim;
    private AritomiTimer m_timerActive;
    private AritomiTimer m_rushTime;
    private AritomiTimer m_spanTimer;
    private float m_sumTime;
    private SpanData m_currntData;
    //******リセットかけないと最大値のままになる
    private int m_spanDataIndex;
    private void Awake()
    {
        m_timerActive = new AritomiTimer(m_fActiveTime);
        m_rushTime = new AritomiTimer(m_fRushTime);
        m_spanDataIndex = 0;
    }

    /// <summary>
    /// 開始
    /// </summary>
    void Start()
    {
        m_anim = new AnimManager();
        m_anim.AddAnimMethod((int)GAME_SCENE_TYPE.GAME_PLAY, GamePlay);
        m_anim.AddAnimMethod((int)GAME_SCENE_TYPE.GAME_RUSH, RushMode);
        m_timerActive.Reset();


        m_spanTimer = new AritomiTimer(0);
        SettingSpan();
        m_sumTime = m_spanDatas.Sum((SpanData _data) => { return _data.m_seconds; });
    }

    private bool SettingSpan()
    {
        m_currntData = m_spanDatas[m_spanDataIndex];
        if (m_currntData == null) return false;
        m_spanTimer.SetTime(m_currntData.m_seconds);
        m_spanDataIndex = Mathf.Clamp(m_spanDataIndex + 1, 0, m_spanDatas.Count - 1);
        return true;
    }

    /// <summary>
    /// SpawnPoleのオブジェクト名の最後が数字なのでその数字を使いソート
    /// Matuo
    /// </summary>
    int NameNumberCompare(SpawnPole _a, SpawnPole _b)
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

    /// <summary>
    /// アニメーションゲームプレイ
    /// </summary>
    private void GamePlay()
    {

        m_timerActive.Update(Time.deltaTime);
        if (m_timerActive.IsTimeOver())
        {
            CreateRandomPole();
        }

        m_spanTimer.Update(Time.deltaTime);
        if (m_spanTimer.IsTimeOver())
        {
            SettingSpan();
        }

    }

    /// <summary>
    /// ラッシュモード
    /// </summary>
    private void RushMode()
    {
        m_rushTime.Update(Time.deltaTime);
        CreateAllPole();

        if (m_rushTime.IsTimeOver())
        {
            m_rushTime.Reset();
            GameManager.main.currentGameType = GAME_SCENE_TYPE.GAME_PLAY;
        }
    }

    /// <summary>
    /// すべてのポールを生成
    /// </summary>
    private void CreateAllPole()
    {
        int index_X = Random.Range(0, 3);
        int index_Y = Random.Range(0, 3);

        int indexObjectPole = Random.Range(0, m_objectPoles.Length);

        CreatePole(index_X, index_Y, indexObjectPole);
    }


    /// <summary>
    /// ポール作成
    /// </summary>
    private void CreateRandomPole()
    {
        if (m_currntData == null)
        {
            Debug.Log("CURRENT_DATA NULL");
            return;
        }
        int index_X = Random.Range(0, 3);
        int index_Y = Random.Range(0, 3);

        if (m_currntData.m_dir == SpanData.DIR.WIDTH)
        {
            index_Y = m_currntData.m_column;
        }
        else
        {
            index_X = m_currntData.m_column;
        }

        int indexObjectPole = Random.Range(0, m_objectPoles.Length);

        CreatePole(index_X, index_Y, indexObjectPole);

        m_timerActive.Reset();
    }

    /// <summary>
    /// ポール作成
    /// </summary>
    /// <param name="_x">x軸</param>
    /// <param name="_y">y軸</param>
    /// <param name="_poletype">ポールタイプ</param>
    private void CreatePole(int _x, int _y, int _poletype)
    {
        var point = m_spawns[_y][_x];

        if (point.HasPole())
        {
            point.Create(m_objectPoles[_poletype], m_score[_y, _x]);
        }
    }
}
