using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Peg))]
public class RingDetection : MonoBehaviour
{
    private Peg peg;
    public Peg Peg { get => peg; }

    private void Awake() {
        this.peg = GetComponent<Peg>();
    }
    
    private void OnTriggerEnter(Collider other) {

        Ring detectedRing = other.GetComponent<Ring>();
        
        if (!DetectedRingIsValid(detectedRing)) return;
        
        else if (detectedRing) 
        {  
            if (peg.CurrentSetOfRings.Count <= 0) AssignNewDropPosition(detectedRing);
            else if (peg.CurrentSetOfRings.Peek().RingSize < detectedRing.RingSize) 
            {
                AssignNewDropPosition(detectedRing);
            }
        }

    }

    private void OnTriggerExit(Collider other) 
    {
        Ring detectedRing = other.GetComponent<Ring>();
        
        if (!DetectedRingIsValid(detectedRing)) return;
        
        else if (detectedRing) {  
            DeclineDrop(detectedRing);
        }
        
    }

    private void AssignNewDropPosition(Ring detectedRing)
    {
        peg.CurrentSetOfRings.Push(detectedRing);
        float y = GameManager.Instance.RingManager.YOffsetPerRing * (peg.CurrentSetOfRings.Count);
        float z = this.peg.transform.position.z;
        detectedRing.DropPosition = new Vector3(0, y, z);
    }

    private void DeclineDrop(Ring detectedRing)
    {
        peg.CurrentSetOfRings.Pop();
        detectedRing.DropPosition = detectedRing.DesignatedPosition;
    }

    private bool DetectedRingIsValid(Ring detectedRing)
    {
        if (!detectedRing) return false;
        else if (peg.CurrentSetOfRings.Contains(detectedRing)) return false;
        else return true;
    }
}