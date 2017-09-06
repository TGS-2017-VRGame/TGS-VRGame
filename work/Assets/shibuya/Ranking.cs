using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public static class Ranking
{
	private static List<int> m_rankData;
	private static int m_score;
	static Ranking()
	{
		m_rankData = new List<int>();
		Load();
	}

	public static void Add(int _score)
	{
		var index = m_rankData.Count - 1;
		m_score = _score;
		m_rankData[index] = (int)Mathf.Max(m_rankData[index], _score);
		m_rankData.Sort();
		m_rankData.Reverse();
	}

	public static List<int> Export()
	{
		return m_rankData;
	}

	public static void Load()
	{
		m_rankData.Clear();
		const int maxCount = 5;
		for (int i = 0; i < maxCount; i++)
		{
			m_rankData.Add(PlayerPrefs.GetInt("rank" + i));
		}
	}

	public static void Seve()
	{
		PlayerPrefs.DeleteAll();
		for (int i = 0; i < m_rankData.Count; i++)
		{
			PlayerPrefs.SetInt("rank" + i, m_rankData[i]);
		}
		PlayerPrefs.Save();
	}

	public static int RankIn()
	{
		var rankData = new List<int>(Ranking.Export());
		rankData.Reverse();
		for (int i = 0; i < rankData.Count; i++)
		{
			if (rankData[i] == m_score)
			{
				return i;
			}
		}
		return -1;
	}

}
