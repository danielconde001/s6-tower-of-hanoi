using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ring))]
public class PegDetection : MonoBehaviour
{
    private Ring ring;

    private Peg pegToDropRingOn; 
    public Peg PegToDropRingOn
    {
        get => pegToDropRingOn;
    }

    private void Awake() {
        ring = this.GetComponent<Ring>();
    }

    private void Start() {
        pegToDropRingOn = ring.RespectivePeg;
    }

    private void OnTriggerEnter(Collider other) {
        Peg detectedPeg = other.GetComponent<Peg>();

        if (!detectedPeg) return;
        if (!PegIsValidToDropRingOn(detectedPeg)) return;

        pegToDropRingOn = detectedPeg;
    }

    private void OnTriggerExit(Collider other) {
        Peg detectedPeg = other.GetComponent<Peg>();

        if (!detectedPeg) return;

        pegToDropRingOn = ring.RespectivePeg;
    }

    private bool PegIsValidToDropRingOn(Peg detectedPeg)
    {
        if (detectedPeg.CurrentSetOfRings.Count <= 0) return true;
        else if (detectedPeg.CurrentSetOfRings.Peek().RingSize < this.ring.RingSize) return false;
        else return true;
    }
}
