using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinCondition : Condition
{
    protected BoardManager boardManager;
    protected RingManager ringManager;

    protected void Start() {
        boardManager = GameManager.Instance.BoardManager;
        ringManager = GameManager.Instance.RingManager;
    }

    protected override bool CheckCondition() 
    {
        for (int i = 0; i < boardManager.PegsOnBoard.Count; i++)
        {
            if (boardManager.PegsOnBoard[i] == boardManager.StartingPeg) continue;
            else if (boardManager.PegsOnBoard[i].StackOfRings.Count >= ringManager.MaxNumberOfRings)
            {
                return true;
            }
        }

        return false;
    }
}
