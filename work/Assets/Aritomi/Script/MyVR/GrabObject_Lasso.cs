using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject_Lasso : GrabObject
{
    TrailRenderer m_trailRenderer;
    protected override void UniqueStart()
    {
        m_trailRenderer = GetComponent<TrailRenderer>();
    }

    protected override void UniqueThrow(float _force)
    {

    }

    private void TrailLength(float _force)
    {
        //m_trailRenderer.
    }
}
