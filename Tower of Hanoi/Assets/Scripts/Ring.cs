using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Draggable))]
public class Ring : MonoBehaviour
{
    [HideInInspector] public Vector3 designatedPosition;
    public Material material;
    [SerializeField] Vector3 Offset;
    float zPos;

    private void Awake() {
        designatedPosition = transform.position;
    }

    private void OnMouseUp() {
        transform.position = designatedPosition;
    }

    private void OnMouseDown()
    {
        zPos = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWolrdPos() + Offset;
    }

    private Vector3 GetMouseWolrdPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zPos;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }


}