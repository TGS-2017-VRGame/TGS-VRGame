using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
public abstract class MyController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_HMD;               //! ヘッドマウント
    [SerializeField]
    private GameObject m_catchPoint = null; //! 掴んだオブジェクトの位置
    [SerializeField]
    private float m_throwPower = 1000f;     //! 投げる力
    [SerializeField]
    private float m_throwRot = 90f;         //! 投げる方向を制御するときの変数

    private int m_grabNum;                  //! 掴んでいる数

    protected bool m_currentIsGrab;         //! 現在の掴んでいるかの状態
    protected bool m_previousIsGrab;        //! ひとつ前の掴んでいるかの状態

    protected Vector3 m_currentPos;         //! 現在の位置
    protected Vector3 m_previousPos;        //! ひとつ前の位置
    protected Queue<Vector3> m_positions = new Queue<Vector3>();   //!

    /// <summary>
    /// 初期化
    /// </summary>
    void Awake()
    {
        GetRigitbody().isKinematic = true;
        UniqeAwake();

        m_grabNum = 0;

        //for (int i = 0; i < 10; i++)
        //{
        //    m_positions.Enqueue(Vector3.zero);
        //}
    }

    protected virtual void UniqeAwake()
    {

    }

    /// <summary>
    /// 開始
    /// </summary>
    void Start()
    {
        m_currentIsGrab = false;
        m_previousIsGrab = false;

        m_currentPos = Vector3.zero;
        m_previousPos = Vector3.zero;

        UniqeStart();
    }

    protected virtual void UniqeStart()
    {

    }

    public void AddGrabNum()
    {
        m_grabNum += 1;
    }

    public int GetGrabNum()
    {
        return m_grabNum;
    }

    public void ResetGrabNum()
    {
        m_grabNum = 0;
    }

    void AddVelocity(Vector3 v)
    {
        m_positions.Enqueue(v);
        if(m_positions.Count>10)
        {
            m_positions.Dequeue();
        }
    }


    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        m_previousIsGrab = m_currentIsGrab;
        m_currentIsGrab = IsGrab();

    }

    /// <summary>
    /// 1フレームごとに更新
    /// </summary>
    void FixedUpdate()
    {
        m_previousPos = m_currentPos;
        m_currentPos = transform.position;

        AddVelocity(m_currentPos - m_previousPos);
    }

    /// <summary>
    /// 投げる
    /// </summary>
    /// <returns>投げた方向のベクトル</returns>
    public Vector3 Throw()
    {
        const float LOW_POWER = 0.01f;
        const float MAX_ANGLE = 90.0f;
       var vels= m_positions.Where((Vector3 v) => { return v.magnitude >= LOW_POWER; })
            .Where((Vector3 v)=> { return Mathf.Abs(Vector3.Angle(m_HMD.transform.position, v)) <= MAX_ANGLE; }).ToList();

        Vector3 result = Vector3.zero;
        foreach(var pos in vels)
        {
            result += pos;
        }
        if (vels.Count <= 0) return Vector3.zero;
        result /= vels.Count;
        m_positions.Clear();
        return result * m_throwPower;
    }

    /// <summary>
    /// 掴んでいるか？
    /// </summary>
    /// <returns></returns>
	public abstract bool IsGrab ();

    /// <summary>
    /// 掴んだ瞬間を返す
    /// </summary>
    /// <returns></returns>
    public bool IsGrabDown()
    {
        return m_currentIsGrab && !m_previousIsGrab;
    }

    public bool IsGrabed()
    {
        return m_previousIsGrab && !m_currentIsGrab;
    }

    /// <summary>
    /// 輪っか生成場所の設定ボタン
    /// </summary>
    /// <returns></returns>
	public abstract bool IsSpawnPointResetButton();

    /// <summary>
    /// 輪っかの生成ボタン
    /// </summary>
    /// <returns></returns>
	public abstract bool IsLassoSpawnButton ();

    /// <summary>
    /// コントローラーの位置
    /// </summary>
    /// <returns></returns>
	public Transform GetTransform()
    {
        return transform;
    }
    
    /// <summary>
    /// 輪っかを飛ばすためのVelocity
    /// </summary>
    /// <returns></returns>
	public Vector3 Velocity()
    {
        return m_currentPos - m_previousPos;
    }

    /// <summary>
    /// 投げる力
    /// </summary>
    /// <returns></returns>
    public float ThrowPower()
    {
        return Vector3.Distance(m_currentPos, m_previousPos);
    }

    public Rigidbody GetRigitbody()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        if (rigidbody == null)
        {
            rigidbody = gameObject.AddComponent<Rigidbody>();
        }

        return rigidbody;
    }
}
