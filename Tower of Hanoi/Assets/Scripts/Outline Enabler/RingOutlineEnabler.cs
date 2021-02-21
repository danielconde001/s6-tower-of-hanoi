using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ring))]
public class RingOutlineEnabler : MouseHoverOutlineEnabler
{
    protected Ring ring;

    protected override void OnMouseEnter()
    {
        if (!ring.IsTopOfStack) return;
        
        base.OnMouseEnter();
    }

    protected override void Awake() 
    {
        base.Awake();
        ring = GetComponent<Ring>();
    }

}
