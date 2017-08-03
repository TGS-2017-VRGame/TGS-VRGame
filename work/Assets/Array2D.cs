using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
Listを二次元配列として扱う
*/
[System.Serializable]
public class Array2D<T>
{
    [SerializeField]
    private List<T> m_array;
    [SerializeField]
    public int m_size0, m_size1;
    public Array2D(int _size0, int _size1)
    {
        m_size0 = _size0;
        m_size1 = _size1;
        m_array = new List<T>(m_size0 * m_size1);
    }
    public List<T> GetArray()
    {
        return m_array;
    }

    public T Get(int _index0, int _index1)
    {
        var index = _index1 * m_size0 + _index0;//実際のアクセス場所
        return m_array[index];
    }
    public bool IsInside(int _index0, int _index1)
    {
        if (_index1 < 0) return false;
        if (_index0 < 0) return false;
        if (m_size1 >= _index1) return false;
        if (m_size0 >= _index0) return false;
        return true;
    }
    public int GetSize0()
    {
        return m_size0;
    }
    public int GetSize1()
    {
        return m_size1;
    }
}
