using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnList
{
    [SerializeField]
    private List<SpawnPole> m_list;

    public SpawnList(List<SpawnPole> _list)
    {
        m_list = _list;
    }

    public SpawnPole this[int i]
    {
        get
        {
            return m_list[i];
        }
        set
        {
            m_list[i] = value;
        }
    }

    public void Add(SpawnPole _item)
    {
        m_list.Add(_item);
    }

    public void RemoveAt(int _index)
    {
        m_list.RemoveAt(_index);
    }

    public bool Remove(SpawnPole _item)
    {
        return m_list.Remove(_item);
    }

    public int RemoveAll(System.Predicate<SpawnPole> _match)
    {
        return m_list.RemoveAll(_match);
    }

    public int Count { get { return m_list.Count; } }
}
