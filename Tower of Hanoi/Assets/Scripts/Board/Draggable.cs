using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    [SerializeField] protected UnityEvent OnLift;
    [SerializeField] protected UnityEvent OnDrop;

    protected virtual void OnMouseUp() {
        if (isDraggable) {
            OnDrop.Invoke();
        }
    }

    protected virtual void OnMouseDown()
    {
        if (isDraggable) {
            zPos = Camera.main.WorldToScreenPoint(transform.position).z;
            OnLift.Invoke();
        }
    }

    protected virtual void OnMouseDrag()
    {
        if (isDraggable) {
            transform.position = GetMouseWolrdPos() + OnDragPositionOffset;
        }
    }

    private Vector3 GetMouseWolrdPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zPos;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
