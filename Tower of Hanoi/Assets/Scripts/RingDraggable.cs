using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Ring), typeof(PegDetection))]
public class RingDraggable : Draggable
{
    private Ring ring;
    private PegDetection pegDetection;

    private Vector3 dropPosition;
    public Vector3 DropPosition 
    {
        get => dropPosition;
        set => dropPosition = value;
    }

    private Vector3 designatedPosition;
    public Vector3 DesignatedPosition 
    {
        get => designatedPosition;
        set => designatedPosition = value;
    }

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
            this.ring.RespectivePeg.CurrentSetOfRings.Pop();
    }

    protected override void OnMouseDrag()
    {
        base.OnMouseDrag();
    }

    private void DropRingOnPeg()
    {
        pegDetection.PegToDropRingOn.CurrentSetOfRings.Push(this.ring);
        Vector3 pegPosition = pegDetection.PegToDropRingOn.transform.position;
        
        int ringCountOnPeg = pegDetection.PegToDropRingOn.CurrentSetOfRings.Count;
        float yOffset = (GameManager.Instance.RingManager.YOffsetPerRing * (ringCountOnPeg));

        pegPosition.y = yOffset;
        this.ring.transform.position = pegPosition;

        this.ring.RespectivePeg = pegDetection.PegToDropRingOn;
    }
}
