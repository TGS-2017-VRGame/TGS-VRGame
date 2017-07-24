using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {
	[SerializeField]
	private GameObject m_camera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = m_camera.transform.position;
		Quaternion rotation = m_camera.transform.rotation;
		rotation.x = gameObject.transform.rotation.x;
		rotation.z = gameObject.transform.rotation.z;
		gameObject.transform.rotation = rotation;
	}
}
