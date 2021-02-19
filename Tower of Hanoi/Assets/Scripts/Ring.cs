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

    public bool IsTopOfPeg 
    { 
        get => respectivePeg.CurrentSetOfRings.Peek() == this; 
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

    private void Start() {
        
        //Debug.Log(IsTopOfPeg, this);
    }

}