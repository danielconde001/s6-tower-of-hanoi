using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class OutlineEnabler : MonoBehaviour
{
    protected Outline outline;
    public Outline Outline
    {
        get => outline;
        set => outline = value;
    }

    [SerializeField] protected float outlineWidth;
    public float OutlineWidth
    {
        get => outlineWidth;
        set => outlineWidth = value;
    }

    protected virtual void Awake() {
        outline = GetComponent<Outline>();
    }

    protected void Enable() {
        outline.OutlineWidth = outlineWidth;
    }

    protected void Disable() {
        outline.OutlineWidth = 0;
    }
}
