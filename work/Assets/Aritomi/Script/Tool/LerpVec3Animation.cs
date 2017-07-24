using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ラープアニメーション用のツール
/// </summary>
public class LerpVec3Animation {
	private List<Vector3> m_anim = new List<Vector3> ();	//! アニメーション用の変数
	private float m_speed;		//! アニメーションスピード
	private float m_time;		//! アニメーションを動かす用の変数

	private float Min (float a, float b) {
		return a < b ? a : b;
	}
	private float Max (float a, float b) {
		return a < b ? b : a;
	}
	private float Clamp(float num, float min, float max) {
		return Min (Max (num, min), max);
	}

	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="startPosition">開始位置</param>
	/// <param name="endPosition">終了位置</param>
	/// <param name="animationTime">アニメーションする時間</param>
	/// <param name="deltaTime">1フレームごとの時間</param>
	public LerpVec3Animation(Vector3 startPosition, Vector3 endPosition, float animationTime, float deltaTime) {
		for (float t = 0; t < animationTime; t += deltaTime) {
			m_anim.Add(Vector3.Lerp(startPosition, endPosition, t / animationTime));
		}
		m_speed = 1;
        m_time = 0;
	}

	/// <summary>
	/// 更新
	/// </summary>
	public void Update() {
		m_time += m_speed;

		m_time =  Clamp ((int)m_time, 0, m_anim.Count - 1);
	}

    public void Reset()
    {
        m_time = 0;
    }

	/// <summary>
	/// アニメーションスピードを設定する
	/// </summary>
	/// <param name="speed">Speed.</param>
	public void SetSpeed(float speed) {
		m_speed = speed;
	}

	/// <summary>
	/// アニメーションを逆再生する
	/// </summary>
	public void Return() {
		m_speed *= -1;
	}

	/// <summary>
	/// アニメーションを取得する
	/// </summary>
	/// <returns>The animation.</returns>
	public Vector3 GetAnimation() {
		return m_anim [(int)m_time];
	}

	/// <summary>
	/// アニメーションが止まっているか？
	/// </summary>
	/// <returns><c>true</c> if this instance is animation stop; otherwise, <c>false</c>.</returns>
	public bool IsAnimationStop() {
		return m_time >= m_anim.Count - 1;
	}
}
