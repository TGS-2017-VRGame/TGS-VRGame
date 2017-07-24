using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{

	public Camera[] cameras;
	public GameObject image;

	private Fade fade;
	private float timer;

	// Use this for initialization
	void Start()
	{
		fade = image.GetComponent<Fade>();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
