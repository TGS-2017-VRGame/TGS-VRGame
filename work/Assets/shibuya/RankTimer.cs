using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankTimer : MonoBehaviour
{


	private float m_timer;
	[SerializeField]
	private float m_endTime;

	private float m_Current;

	// Use this for initialization
	void Start()
	{
		m_endTime = m_endTime * 60;
	}

	public void Cout()
	{
		if (m_endTime >= m_timer) m_timer++;
	}

	public bool isEnd()
	{
		return (m_endTime <= m_timer);
	}

	public void Reset()
	{
		m_timer = 0;
	}

	public void Reset(float _timer)
	{
		m_timer = 0;
		m_endTime = _timer * 60;
	}
}
