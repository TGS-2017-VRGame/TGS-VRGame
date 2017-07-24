using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRControllerL : MyController
{

    public override bool IsGrab()
    {
        //みぎ中指
        return OVRInput.Get(OVRInput.RawButton.LIndexTrigger);
    }

    public override bool IsLassoSpawnButton()
    {
        return OVRInput.GetDown(OVRInput.RawButton.X);
    }

    public override bool IsSpawnPointResetButton()
    {
        return OVRInput.GetDown(OVRInput.RawButton.Y);
    }
}
