using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// つかめるオブジェクト
/// 有冨勇帆
/// </summary>
public class GrabObject : MonoBehaviour
{
    [SerializeField]
    private GameObject m_controller = null;
    [SerializeField]
    private float m_power = 0.5f;

    private FixedJoint m_joint = null;

    private bool m_isGrab;
    private bool m_isGrabed;

    void Awake()
    {
    }

    /// <summary>
    /// 開始
    /// </summary>
    void Start()
    {
        m_isGrab = false;
        m_isGrabed = false;
        m_controller = null;
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        Grab();

        DestroyController();
    }

    /// <summary>
    /// 衝突し続けている処理
    /// </summary>
    /// <param name="col">Col.</param>
    void OnTriggerStay(Collider col)
    {
        AttachController(col.gameObject);
    }

    /// <summary>
    /// コントローラーをアタッチする
    /// </summary>
    /// <param name="col"></param>
    public void AttachController(GameObject controller)
    {
        if (!controller.tag.Contains("Controller"))
        {
            //Debug.LogError("コントローラーがないです");
            return;
        }

        if (HasController())
        {
            //Debug.LogError("コントローラーをもう持っています");
            return;
        }

        m_controller = controller;
    }

    /// <summary>
    /// コントローラーをリタッチ（？）する
    /// </summary>
    private void DestroyController()
    {
        if (!HasController())
        {
            return;
        }

        MyController controller = m_controller.GetComponent<MyController>();

        if (controller == null)
        {
            return;
        }

        if (controller.IsGrab())
        {
            return;
        }

        m_controller = null;
    }

    /// <summary>
    /// コントローラーを持っているか？
    /// </summary>
    /// <returns></returns>
    public bool HasController()
    {
        if (m_controller == null)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// 掴む処理
    /// </summary>
    private void Grab()
    {
        if (!HasController())
        {
            return;
        }

        MyController controller = m_controller.GetComponent<MyController>();

        if (controller == null)
        {
            return;
        }

        if (controller.IsGrab())
        {
            AttachFixedJoint();
            controller.AddGrabNum();
        }

        if (!controller.IsGrab())
        {
            DestroyJoint();
            controller.ResetGrabNum();
        }
    }

    /// <summary>
    /// ジョイントを持っているか？
    /// </summary>
    /// <returns></returns>
    private bool HasJoint()

    {
        return GetComponent<FixedJoint>();
        //if ((GetComponent<FixedJoint>()) == null)
        //{
        //     return false;
        //}

        //return true;
    }

    /// <summary>
    /// ジョイントをアタッチする
    /// </summary>
    /// <param name="objcet"></param>
    private void AttachFixedJoint()
    {
        FixedJoint joint;
        Rigidbody rigidbody;

        if (!HasController())
        {
            return;
        }

        MyController controller = m_controller.GetComponent<MyController>();

        if (controller == null)
        {
            return;
        }

        if (controller.GetGrabNum() != 0)
        {
            return;
        }

        if ((joint = GetComponent<FixedJoint>()) == null)
        {
            joint = gameObject.AddComponent<FixedJoint>();
        }

        if (joint.connectedBody != null)
        {
            return;
        }

        if ((rigidbody = m_controller.GetComponent<Rigidbody>()) == null)
        {
            rigidbody = m_controller.AddComponent<Rigidbody>(); //柔軟
        }

        transform.position = controller.GetTransform().position;
        joint.connectedBody = rigidbody;
    }

    /// <summary>
    /// ジョイントを削除する
    /// 
    /// </summary>
    private void DestroyJoint()
    {
        FixedJoint joint;
        if ((joint = GetComponent<FixedJoint>()) == null)
        {
            return;
        }

        //このリジットボディ何に使ってるの？
        //AddForce用だよ by Aritomi
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        MyController controller = m_controller.GetComponent<MyController>();
        Destroy(joint);
        var force = controller.Throw();
        rigidbody.AddForce(force);
        Debug.Log(force);

        m_isGrabed = true;
    }

    /// <summary>
    /// つかんでいるかどうか
    /// </summary>
    /// <returns><c>true</c> if this instance is grab; otherwise, <c>false</c>.</returns>
    public bool IsGrab()
    {
        return m_isGrab;
    }

    /// <summary>
    /// 一度でもつかんでいるか？
    /// </summary>
    /// <returns><c>true</c> if this instance is grabed; otherwise, <c>false</c>.</returns>
    public bool IsGrabed()
    {
        return m_isGrabed;
    }
}
