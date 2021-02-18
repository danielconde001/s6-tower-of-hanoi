using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Draggable), typeof(Ring))]
public class SeeThroughOnDrag : MonoBehaviour
{
    [SerializeField] private Material seeThroughMaterial;
    [SerializeField] private Material defaultMaterial;
    private Renderer _renderer;
    private Ring ring;
    private Draggable draggable;

    private void Awake() {
        this._renderer = GetComponent<Renderer>();
        ring = GetComponent<Ring>();
        draggable = GetComponent<Draggable>();
    }

    private void OnEnable() {
        draggable.onMouseDrag += SeeThrough;
        draggable.onMouseUp += ReturnToDefaultMaterial;
    }

     private void OnDisable() {
        draggable.onMouseDrag -= SeeThrough;
        draggable.onMouseUp -= ReturnToDefaultMaterial;
    }

    public void SeeThrough()
    {
        this._renderer.material = seeThroughMaterial;
        this._renderer.material.color = ring.RingColor;
        this._renderer.material.SetColor("See-Through Color", this._renderer.material.color);
    }

    public void ReturnToDefaultMaterial()
    {
        Debug.Log("Called 2");
        this._renderer.material = defaultMaterial;
        this._renderer.material.color = ring.RingColor;
    }
}
