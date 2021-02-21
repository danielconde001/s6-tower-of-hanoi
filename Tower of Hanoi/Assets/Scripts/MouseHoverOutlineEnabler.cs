using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverOutlineEnabler : OutlineEnabler
{
    protected virtual void OnMouseEnter() 
    {
        Enable();
    }

    protected virtual void OnMouseExit() 
    {
        Disable();
    }
}
