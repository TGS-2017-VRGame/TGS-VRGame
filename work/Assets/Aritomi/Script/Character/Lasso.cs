using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Examples;

public class Lasso : MonoBehaviour
{
	[SerializeField]
	private float destroyTime = 5;

	private bool isDestroy;
	private GrabObject grab;

	// Use this for initialization
	void Start () {
		isDestroy = false;
		grab = GetComponent<GrabObject> ();
		//gameObject.GetComponent<Rigidbody> ().useGravity = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (grab.IsGrabed())
        {
            isDestroy = true;
            //transform.rotation = Quaternion.identity;
        }

        if (isDestroy)
        {
            Destroy(this.gameObject, destroyTime);
        }
        //Destroy(gameObject, destroyTime);
    }
}
