using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] protected bool isDraggable;
    public bool IsDraggable
    {
        get => isDraggable;
        set => isDraggable = value;
    }

    [SerializeField] protected Vector3 OnDragPositionOffset;
    protected float zPos;

    protected virtual void OnMouseUp() {
        if (isDraggable)
            transform.position = transform.position - OnDragPositionOffset;
    }

    protected virtual void OnMouseDown()
    {
        if (isDraggable)
            zPos = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    protected virtual void OnMouseDrag()
    {
        if (isDraggable)
            transform.position = GetMouseWolrdPos() + OnDragPositionOffset;
    }

    private Vector3 GetMouseWolrdPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zPos;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
