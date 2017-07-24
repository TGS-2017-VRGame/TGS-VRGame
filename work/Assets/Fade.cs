using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public enum State
{
    FADEIN = 0,
    FADEOUT = 1
}
public class Fade : MonoBehaviour
{
    private MaskableGraphic m_image;
    [SerializeField]
    private float m_fadeTime;
    [SerializeField]
    private bool m_playOnAwake = false;

    public float FadeTime
    {
        set
        {
            m_fadeTime = value;
        }
        get
        {
            return m_fadeTime;
        }
    }
    MaskableGraphic Image
    {
        get
        {
            if (m_image == null)
            {
                m_image = GetComponent<MaskableGraphic>();
            }
            return m_image;
        }
    }

    // Use this for initialization
    void Start()
    {
        if(m_playOnAwake)
        {
            FadeStart(State.FADEOUT);
        }
    }

    IEnumerator FadeUpdate(Color _addColor, Action _action)
    {
        for (int i = 0; i < 100; i++)
        {
            Image.color += _addColor;
            yield return new WaitForSeconds(m_fadeTime / 100);
        }
        if (_action != null)
        {
            _action();
        }
    }

    private void SetAlpha(float alpha)
    {
        Color color = Image.color;
        color.a = alpha;
        Image.color = color;
    }

    public void FadeStart(State _state, Action _action = null)
    {
        Color color = new Color(0, 0, 0, 0.01f);
        if (_state == State.FADEOUT)
        {
            color *= -1;
        }
        SetAlpha((int)_state);
        StartCoroutine(FadeUpdate(color, _action));
    }
}
