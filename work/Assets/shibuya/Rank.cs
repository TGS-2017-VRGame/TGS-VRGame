using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Rank : MonoBehaviour
{


	[SerializeField]
	private Text[] m_text;

	[SerializeField]
	private float[] m_posY;

	private RankTimer m_timer;

	private int m_count = 0;
	private float m_feadTime = 0;
	private bool m_feadChange = false;

	// Use this for initialization
	void Start()
	{
		m_timer = GetComponent<RankTimer>();

		Ranking.Add(1250);
		//ランクインした奴を赤くする
		if (Ranking.RankIn() != -1) m_text[Ranking.RankIn()].color = new Color(1, 0, 0);
		Ranking.Seve();
		RankData();

	}

	// Update is called once per frame
	void Update()
	{
		Move(5.0f);
		if (Ranking.RankIn() != -1) Fead();
		if (Input.GetKeyDown(KeyCode.Space))
		{
			PlayerPrefs.DeleteAll();
		}
	}

	void Move(float _speed)
	{
		//指定の場所まで移動
		if (m_text[m_count].transform.position.y >= m_posY[m_count])
		{
			m_text[m_count].transform.position -= new Vector3(0, _speed, 0);
		}

		//今のが指定の場所まで行ったら次の物を指定
		if (m_text[m_count].transform.position.y <= m_posY[m_count])
		{
			if(m_count != 4) m_timer.Cout();
			if (m_timer.isEnd())
			{
				m_timer.Reset(0.5f);
				if (m_text.Length - 1 > m_count) m_count++;
				m_text[m_count].gameObject.SetActive(true);
			}
		}
	}


	void Fade(float _time)
	{
		m_feadTime = 1 / (_time * 60);
		m_text[Ranking.RankIn()].color += new Color(0, 0, 0, m_feadTime);
	}

	void Fead()
	{
		if (!m_feadChange)
		{
			Fade(2 * -1);
			if (m_text[Ranking.RankIn()].color.a <= 0) m_feadChange = true;
		}

		if (m_feadChange)
		{
			Fade(2);
			if (m_text[Ranking.RankIn()].color.a >= 1) m_feadChange = false;
		}
	}

	void RankData()
	{
		int rank = 1;
		var rankData = new List<int>(Ranking.Export());

		var index = m_text.Length - 1;
		for (int a = 0; a < m_text.Length; a++)
		{
			if (a != 0) m_text[a].gameObject.SetActive(false);
			if (a > 0)
			{
				if (rankData[a - 1] != rankData[a])
				{
					rank++;
				}
			}
			m_text[index - a].text = rank.ToString() + "：" + rankData[a].ToString();
		}
	}
}