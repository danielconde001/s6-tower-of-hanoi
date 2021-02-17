using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Peg))]
public class RingDetection : MonoBehaviour
{
    private Peg assignedPeg;
    
    [SerializeField] private Condition ringIsValid;
    [SerializeField] private Condition ringBelongsToAssignedPeg;
    
    private Ring detectedRing;
    public Ring DetectedRing { get => detectedRing; }

    private void Awake() {
        assignedPeg = GetComponent<Peg>();
    }
    
    private void OnTriggerEnter(Collider other) {

        detectedRing = other.GetComponent<Ring>();
        
        if (!detectedRing) return;
        
        else if (detectedRing) {  
            if (ringIsValid.Check()) {
                // do the math
                float y = GameManager.Instance.BoardManager.PositionYOffset;
                float z = assignedPeg.transform.position.z;
                detectedRing.DesignatedPosition = 
                new Vector3(0, y, z);
            }
        }

    }

    private void OnTriggerExit(Collider other) {

    }
}
