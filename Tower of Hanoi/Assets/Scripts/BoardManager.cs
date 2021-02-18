using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private List<Peg> pegs = new List<Peg>();
    public List<Peg> Pegs { get => pegs; }

    public Peg StartingPeg { get => pegs[0]; }

    private Condition winCondition; // Might want to put this somewhere else more appropriate

    private void Awake() {
        winCondition = GetComponent<Condition>();
    }

    void Update()
    {
       // if (winCondition.Check()) print("Condition met!"); // Debug purposes
    }

}
