﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	//private Fade fade;
	[SerializeField]
	Fade m_fadeImage;
    [SerializeField]
    Fade m_titleImae;
	[SerializeField]
	private GameObject[] m_destroyObjects = new GameObject[0];

    // Use this for initialization
    void Start()
	{
        m_titleImae.FadeStart(State.FADEOUT, RawImageFadeStart);
	}

	/// <summary>
	/// fadeが終わったときに処理する
	/// </summary>
	void FadeEnd()
	{
		iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("NewPath1"), "time", 10.0f));
        for (int i = 0; i < m_destroyObjects.Length; i++)
        {
            Destroy(m_destroyObjects[i]);
        }
    }

    void RawImageFadeStart()
    {
        m_fadeImage.FadeStart(State.FADEOUT, FadeEnd);
    }
	// Update is called once per frame
	void Update()
	{
	}


}
