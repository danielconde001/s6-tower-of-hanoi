using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegHasAllRingsCondition : Condition
{
    BoardManager boardManager;
    RingManager ringManager;

    private void Awake() {
        boardManager = GameManager.Instance.BoardManager;
        ringManager = GameManager.Instance.RingManager;
    }

    public override bool Check()
    {
        for (int i = 0; i < boardManager.Pegs.Count; i++)
        {
            if (boardManager.Pegs[i] == boardManager.StartingPeg) continue;

            else if (boardManager.Pegs[i].CurrentSetOfRings.Count >= ringManager.MaxNumberOfRings)
            {
                return true;
            }       
        }
        return false;
    }
}
