using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour
{
    private Stack<Ring> currentSetOfRings = new Stack<Ring>();
    public Stack<Ring> CurrentSetOfRings { get => currentSetOfRings; }
}
