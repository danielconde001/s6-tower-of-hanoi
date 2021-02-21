using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Peg))]
public class PegOutlineEnabler : OnTriggerOutlineEnabler
{
    protected Peg peg;

    [SerializeField] protected Color positiveColor;
    [SerializeField] protected Color negativeColor;

    protected Ring detectedRing;

    protected override void Awake()
    {
        base.Awake();
        peg = GetComponent<Peg>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        detectedRing = other.GetComponent<Ring>();

        if (!detectedRing) return;

        base.OnTriggerEnter(other);

        outline.OutlineColor = ProvideOutlineColor(detectedRing);
    }

    protected virtual Color ProvideOutlineColor(Ring ring)
    {
        if (peg.StackOfRings.Count <= 0)
            return positiveColor;
        if (detectedRing.RingSize < peg.StackOfRings.Peek().RingSize)
            return positiveColor;
        else
            return negativeColor;
    }

    protected virtual void Update() {
        
        if (!detectedRing) return;
        
        else DisableOnRingDrop();  
    }

    protected virtual void DisableOnRingDrop()
    {
       if(this.peg.StackOfRings.Contains(detectedRing))
       {
           Disable();
       }
    }
}
