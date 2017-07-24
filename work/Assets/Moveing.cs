using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Moveing : MonoBehaviour
{
    [SerializeField]
    private Transform m_root;
    [SerializeField]
    private float m_speed=3f;
    private Vector3[] m_points;
    private Vector3 m_target;
    private int m_destpoint;
    // Use this for initialization
    void Start()
    {
        int index = m_root.childCount;
        m_points = new Vector3[index];
        for (var i = 0; i < index; i++)
        {
            m_points[i] = m_root.GetChild(i).position;
        }
        GoToNextPoint();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += (m_target - transform.position).normalized*Time.deltaTime* m_speed;// Vector3.Lerp(transform.position,m_target, m_step);
        if(Vector3.Distance(m_target,transform.position)<0.5f)
        {
            GoToNextPoint();
        }
    }

    private void GoToNextPoint()
    {
        m_target = m_points[m_destpoint];
        m_destpoint = (m_destpoint + 1) % m_points.Length;
    }

}
