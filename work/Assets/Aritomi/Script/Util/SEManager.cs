using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    public static SEManager main;

    [SerializeField]
    private List<AudioSource> m_se = null;

    private Dictionary<string, AudioSource> m_seDir;


    void Awake()
    {
        main = this;
    }

    // Use this for initialization
    void Start()
    {
        m_seDir = new Dictionary<string, AudioSource>();
        
        foreach(AudioSource audio in m_se)
        {
            m_seDir.Add(audio.clip.name, audio);
        }
    }

    //
    public void PlayOneShot(string _name)
    {
        m_seDir[_name].PlayOneShot(m_seDir[_name].clip);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
