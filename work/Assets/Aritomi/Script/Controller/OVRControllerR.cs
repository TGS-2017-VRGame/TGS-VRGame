using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRControllerR : MyController
{

    public override bool IsGrab()
    {
        //みぎ中指
        return OVRInput.Get(OVRInput.RawButton.RIndexTrigger);
    }

    public override bool IsLassoSpawnButton()
    {
        return OVRInput.GetDown(OVRInput.RawButton.A);
    }

    public override bool IsSpawnPointResetButton()
    {
        return OVRInput.GetDown(OVRInput.RawButton.B);
    }
}
