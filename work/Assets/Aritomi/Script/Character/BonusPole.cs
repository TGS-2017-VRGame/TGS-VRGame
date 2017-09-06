using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPole : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider _col)
    {
        if (_col.tag.Contains("Lasso"))
        {
            FlagAssistant.main.IsRushMode = true;
            GetComponent<Collider>().enabled = false;
        }
    }
}
