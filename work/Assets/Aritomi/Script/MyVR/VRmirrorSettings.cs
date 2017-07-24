using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRmirrorSettings : MonoBehaviour
{
    [SerializeField]
    private bool showDeviceView = true;

    // Use this for initialization
    void Start()
    {
        UnityEngine.VR.VRSettings.showDeviceView = showDeviceView;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
