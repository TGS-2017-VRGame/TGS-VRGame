using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーンの状態
/// 有冨
/// </summary>
public enum GAME_SCENE_TYPE
{
    GAME_START = 0,     //! ゲームスタート
    GAME_PLAY,          //! ゲームプレイ
    GAME_RUSH,          //! ラッシュ
    GAME_END            //! ゲームエンド
}

public enum RING_TYPE
{
    NORMAL = 0,
    BIG,
}

/// <summary>
/// ゲーム管理者
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager main = null;      // シングルトン
    public GAME_SCENE_TYPE currentGameType;   // 現在のゲームタイプ
    public RING_TYPE currentRingType;

    [SerializeField]
    private GameObject m_ControllerObjectL = null;
    [SerializeField]
    private GameObject m_ControllerObjectR = null;
    [SerializeField]
    private GameObject m_Ring = null;
    [SerializeField]
    private GameObject m_BigRing = null;
    [SerializeField]
    private GameObject m_gameStartObject = null;
    [SerializeField]
    private Timer m_timer = null;
    [SerializeField]
    private Score m_score = null;

    private AritomiTimer m_isThrowTimer;

    private MyController m_ControllerL;   // 右コントローラー
    private MyController m_ControllerR;   // 左コントローラー

    /// <summary>
    /// 初期化
    /// </summary>
    void Awake()
    {
        main = this;
    }

    /// <summary>
    /// 開始
    /// </summary>
    void Start()
    {
        // オブジェクトがあるか調べる
        if (!HasGameObject(m_ControllerObjectL) || !HasGameObject(m_ControllerObjectR))
        {
            Debug.LogError("コントローラーがありません");
            return;
        }

        // コントローラーコンポーネントがアタッチされているか調べる
        if (!GetControllerL(m_ControllerObjectL) || !GetControllerR(m_ControllerObjectR))
        {
            Debug.LogError("コントローラーコンポーネントがありません");
        }

        m_timer.IsStop = true;

        currentGameType = GAME_SCENE_TYPE.GAME_START;

        m_isThrowTimer = new AritomiTimer(0);

        m_score = GameObject.Find("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        m_isThrowTimer.Update(Time.deltaTime);

        SpawnRingL();
        SpawnRingR();
        GameStartObjectUpdate();
        GameOver();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameManager.main.currentGameType = GAME_SCENE_TYPE.GAME_RUSH;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.main.currentGameType = GAME_SCENE_TYPE.GAME_PLAY;
            m_timer.IsStop = false;
            m_score.Reset();
            //ポールマネージャのリセットもしといて
        }
    }

    /// <summary>
    /// ゲームスタートオブジェクトこうしん
    /// </summary>
    private void GameStartObjectUpdate()
    {
        if (!m_gameStartObject)
        {
            return;
        }

        bool isActive = currentGameType == GAME_SCENE_TYPE.GAME_START;

        m_gameStartObject.SetActive(isActive);
    }

    private void GameOver()
    {
        if (m_timer.IsEnd())
        {
            currentGameType = GAME_SCENE_TYPE.GAME_START;
            m_timer.IsStop = true;
            m_timer.ResetTime();
        }
    }

    /// <summary>
    /// Ringを召喚する
    /// </summary>
    private void SpawnRingL()
    {
        bool isSpawn = HasControllerL() && HasGameObject(m_Ring) && m_isThrowTimer.IsTimeOver();

        if (!isSpawn)
        {
            return;
        }

        if (m_ControllerL.IsGrabDown())
        {
            Vector3 pos;
            Quaternion rot;
            GrabObject lasso;

            switch (currentRingType)
            {
                case RING_TYPE.NORMAL:
                    pos = m_ControllerL.GetTransform().position;
                    rot = m_ControllerL.GetTransform().rotation;
                    lasso = Instantiate(m_Ring, pos, rot).GetComponent<GrabObject>();
                    lasso.AttachController(m_ControllerObjectL);
                    break;

                case RING_TYPE.BIG:
                    pos = m_ControllerL.GetTransform().position;
                    rot = m_ControllerL.GetTransform().rotation;
                    lasso = Instantiate(m_BigRing, pos, rot).GetComponent<GrabObject>();
                    lasso.AttachController(m_ControllerObjectL);
                    break;
            }
            m_isThrowTimer.SetTime(1);
        }
    }

    private void SpawnRingR()
    {
        bool isSpawn = HasControllerR() && HasGameObject(m_Ring) && m_isThrowTimer.IsTimeOver();

        if (!isSpawn)
        {
            return;
        }

        if (m_ControllerR.IsGrabDown())
        {
            Vector3 pos;
            Quaternion rot;
            GrabObject lasso;

            switch (currentRingType)
            {
                case RING_TYPE.NORMAL:
                    pos = m_ControllerR.GetTransform().position;
                    rot = m_ControllerR.GetTransform().rotation;
                    lasso = Instantiate(m_Ring, pos, rot).GetComponent<GrabObject>();
                    lasso.AttachController(m_ControllerObjectR);
                    break;

                case RING_TYPE.BIG:
                    pos = m_ControllerR.GetTransform().position;
                    rot = m_ControllerR.GetTransform().rotation;
                    lasso = Instantiate(m_BigRing, pos, rot).GetComponent<GrabObject>();
                    lasso.AttachController(m_ControllerObjectR);
                    break;
            }
            currentRingType = RING_TYPE.NORMAL;
            m_isThrowTimer.SetTime(1);
        }
    }

    /// <summary>
    /// オブジェクトが有効か調べる
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private bool HasGameObject(GameObject obj)
    {
        if (obj == null)
        {
            Debug.LogError("オブジェクトがありません");
            return false;
        }
        return true;
    }

    /// <summary>
    /// 左のコントローラーコンポーネントを取得する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private bool GetControllerL(GameObject obj)
    {
        return (m_ControllerL = obj.GetComponent<MyController>()) != null;
    }

    /// <summary>
    /// 右のコントローラーコンポーネントを取得する
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private bool GetControllerR(GameObject obj)
    {
        return (m_ControllerR = obj.GetComponent<MyController>()) != null;
    }

    /// <summary>
    /// 左のコントローラーがあるかどうか
    /// </summary>
    /// <returns></returns>
    private bool HasControllerL()
    {
        if (m_ControllerL == null)
        {
            Debug.LogError("左のコントローラーがありません");
            return false;
        }
        return true;
    }

    /// <summary>
    /// 右のコントローラーがあるかどうか？
    /// </summary>
    /// <returns></returns>
    private bool HasControllerR()
    {
        if (m_ControllerR == null)
        {
            Debug.LogError("左のコントローラーがありません");
            return false;
        }
        return true;
    }
}
