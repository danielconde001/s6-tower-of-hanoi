using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour
{
    private Stack<Ring> stackOfRings = new Stack<Ring>();
    public Stack<Ring> StackOfRings { get => stackOfRings; }
}
