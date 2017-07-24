using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowLasso : MonoBehaviour {
	private GameObject m_controller;	//! コントローラー
	private Vector3 m_position;			//! 位置

	/// <summary>
	/// 開始
	/// </summary>
	void Start () {
		m_controller = null;
	}
	
	/// <summary>
	/// 更新
	/// </summary>
	void Update () {
		
	}

	/// <summary>
	/// 衝突判定を抜けたときの処理
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerExit(Collider col) {
		if (!col.gameObject.tag.Contains ("Controller")) {
			return;
		}

		m_controller = col.gameObject;

		m_position = m_controller.transform.position;
	}

	public Vector3 Velocity() {
		if (m_controller == null) {
			return Vector3.zero;
		}

		return m_controller.transform.position - m_controller.transform.position;
	}
}
