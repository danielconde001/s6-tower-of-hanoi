using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private Peg respectivePeg;
    public Peg RespectivePeg
    {
        get => respectivePeg;
        set => respectivePeg = value;
    }

    private bool isTopOfStack()
    {
        if (respectivePeg.StackOfRings.Count <= 0) return true;
        else if (respectivePeg.StackOfRings.Peek() == this) return true;
        else return false;
    }
    public bool IsTopOfStack 
    { 
        get => isTopOfStack(); 
    }

    private float ringSize;
    public float RingSize 
    { 
        get => ringSize; 
        set => ringSize = value; 
    } 

    private Material material;

    public Color RingColor 
    { 
        get => this.material.color;
        set => this.material.color = value; 
    } 
    
    private void Awake() {
        material = GetComponent<Renderer>().material;
    }

}