using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//public delegate void Event();

public class RawImageFade : MonoBehaviour {
	private RawImage m_rawImage;
	[SerializeField]
	private float m_speed;
    [SerializeField]
    Image m_image;

	private Event m_event;
	private Action m_callback;

	public void SetEvent(Action _action)
	{
		m_callback = _action;
	}

	void Awake()
	{
		m_rawImage = GetComponent<RawImage>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Fade();
		if(m_rawImage.color.a <= 0.0f)
		{
            if(m_callback != null)
            {
                m_callback();
            }
			
			Destroy(this);
		}
	}

	/// <summary>
	/// rawImageのalpha値を減らす
	/// </summary>
	void Fade()
	{
		Color alpha = m_rawImage.color;
		alpha.a -= m_speed * Time.deltaTime;
		m_rawImage.color = alpha;
        if(m_image != null)
        {
            m_image.color = alpha;
        }
        

    }
}
