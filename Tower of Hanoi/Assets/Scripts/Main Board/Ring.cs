using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Draggable))]
public class Ring : MonoBehaviour
{
    private Draggable draggable;   
    
    public Vector3 DesignatedPosition 
    { 
        get => draggable.designatedPosition; 
        set => draggable.designatedPosition = value; 
    } 
    
    private int ringSize;
    public int RingSize 
    { 
        get => ringSize; 
        set => ringSize = value; 
    } 

    [HideInInspector] private Material material;
    public Material Material 
    { 
        get => material; 
        set => material = value; 
    } 
    
    private void Awake() {
        draggable = GetComponent<Draggable>();
    }

}