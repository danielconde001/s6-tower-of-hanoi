using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Peg), typeof(RingDetection))]
public class RingIsValidCondition : Condition
{
    private Peg assignedPeg;
    private RingDetection ringDetection;

    private void Awake() {
        assignedPeg = GetComponent<Peg>();
        ringDetection = GetComponent<RingDetection>();  
    }

    public override bool Check()
    {
        if (assignedPeg.CurrentSetOfRings.Count <= 0) {
            Debug.Log("It works!", this);
            return true;
        }
        else if (assignedPeg.CurrentSetOfRings.Peek().RingSize < ringDetection.DetectedRing.RingSize) 
            return true;
        else 
            return false;
    }
}
