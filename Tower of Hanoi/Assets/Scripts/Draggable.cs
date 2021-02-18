using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Draggable : MonoBehaviour
{
    public Vector3 dropPosition;
    public Vector3 designatedPosition;
    [SerializeField] Vector3 OnDragPositionOffset;
    float zPos;

    public delegate void ClickAction();
    public event ClickAction onMouseDrag;
    public event ClickAction onMouseUp;

    private void OnMouseUp() {
        transform.position = dropPosition;
        designatedPosition = dropPosition;
        onMouseUp();
    }

    private void OnMouseDown()
    {
        zPos = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWolrdPos() + OnDragPositionOffset;
        onMouseDrag();
    }

    private Vector3 GetMouseWolrdPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zPos;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
