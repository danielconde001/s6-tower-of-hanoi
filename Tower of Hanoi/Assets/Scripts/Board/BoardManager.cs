using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BoardManager : MonoBehaviour
{
    [SerializeField] private List<Peg> pegsOnBoard = new List<Peg>();
    public List<Peg> PegsOnBoard { get => pegsOnBoard; }

    public Peg StartingPeg { get => pegsOnBoard[0]; }

    private void Update() {
        //Debug.Log(pegsOnBoard[0].StackOfRings.Count + ", " + pegsOnBoard[1].StackOfRings.Count + ", " + pegsOnBoard[2].StackOfRings.Count);
    }

}
