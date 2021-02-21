using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerOutlineEnabler : OutlineEnabler
{
    protected virtual void OnTriggerEnter(Collider other) 
    {
        outline.OutlineWidth = outlineWidth;
    }

    protected virtual void OnTriggerExit(Collider other) 
    {
        outline.OutlineWidth = 0;
    }
}
