using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
構造体が望ましいがインスペクタに表示されないのでクラスにしている
*/
[System.Serializable]
public class SpanData
{
    public enum DIR
    {
        WIDTH,
        HEIGHT
    }

    public DIR m_dir;
    public int m_column;
    public float m_seconds;
    public SpanData(DIR _dir, int _column, float _seconds)
    {
        m_dir = _dir;
        m_column = _column;
        m_seconds = _seconds;
    }
    public SpanData()
    {
        m_dir = DIR.WIDTH;
        m_column = 0;
        m_seconds = 0;
    }
}
