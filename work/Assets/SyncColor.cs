using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyncColor : MonoBehaviour {
    [SerializeField]
    MaskableGraphic m_from;
    MaskableGraphic m_self;
    // Use this for initialization
    void Start () {
        m_self = GetComponent<MaskableGraphic>();
	}
	
	// Update is called once per frame
	void Update () {
        m_self.color = m_from.color;
	}
}
