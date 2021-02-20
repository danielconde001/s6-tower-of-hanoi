using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Ring), typeof(PegDetection))]
public class RingDraggable : Draggable
{
    private Ring ring;
    private PegDetection pegDetection;

    private void Awake() {
        ring = GetComponent<Ring>();
        pegDetection = GetComponent<PegDetection>();
    }

    protected override void OnMouseUp()
    {
        if (isDraggable)
            DropRingOnPeg();
    }

    protected override void OnMouseDown() 
    {
        base.OnMouseDown();
        
        if (isDraggable)
            this.ring.RespectivePeg.StackOfRings.Pop();
    }

    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
        
        if (isDraggable) {
            GameManager.Instance.RingManager.CurrentlyDraggedRing = this.ring;
            GameManager.Instance.RingManager.OnRingDrag();
        }
    }

    private void DropRingOnPeg()
    {
        pegDetection.PegToDropRingOn.StackOfRings.Push(this.ring);
        Vector3 pegPosition = pegDetection.PegToDropRingOn.transform.position;
        
        int ringCountOnPeg = pegDetection.PegToDropRingOn.StackOfRings.Count;
        float yOffset = (GameManager.Instance.RingManager.YOffsetPerRing * (ringCountOnPeg));

        pegPosition.y = yOffset;
        this.ring.transform.position = pegPosition;

        this.ring.RespectivePeg = pegDetection.PegToDropRingOn;  

        GameManager.Instance.RingManager.OnRingDrop();     
    }
}
