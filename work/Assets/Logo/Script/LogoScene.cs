using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScene : MonoBehaviour {
    [SerializeField]
    Fade m_fade;
	// Use this for initialization
	void Start () {
        m_fade.FadeStart(State.FADEIN, FadeOutStart);
	}
	
	// Update is called once per frame
	void Update () {

	}

    /// <summary>
    /// 
    /// </summary>
    void FadeOutStart()
    {
        m_fade.FadeStart(State.FADEOUT, ChangeScene);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Title");
    }
}
