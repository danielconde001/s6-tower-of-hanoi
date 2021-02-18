using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Draggable))]
public class Ring : MonoBehaviour
{
    private Draggable draggable;
    public Draggable Draggable
    {
        get => draggable;
    }
    
    // Default position of Ring in case Ring couldn't find an appropriate Peg
    public Vector3 DesignatedPosition 
    { 
        get => draggable.designatedPosition; 
        set => draggable.designatedPosition = value; 
    }

    // Position where Ring will drop to
    public Vector3 DropPosition 
    { 
        get => draggable.dropPosition; 
        set => draggable.dropPosition = value; 
    }

    private float ringSize;
    public float RingSize 
    { 
        get => ringSize; 
        set => ringSize = value; 
    } 

    private Material material;
    public Material Material
    {
        get => material;
        set => material = value;
    }

    public Color RingColor 
    { 
        get => this.material.color;
        set => this.material.color = value; 
    } 
    
    private void Awake() {
        draggable = GetComponent<Draggable>();
        material = GetComponent<Renderer>().material;
    }

}