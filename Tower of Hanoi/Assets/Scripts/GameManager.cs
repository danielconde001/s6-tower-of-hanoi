using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get 
        {
            if (!GameObject.FindObjectOfType<GameManager>())
            {
                GameObject newGameObject = new GameObject("GameManager");
                instance =  newGameObject.AddComponent<GameManager>();
            }
            else if (GameObject.FindObjectOfType<GameManager>()) 
            {
                instance = GameObject.FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    #endregion

    private void Awake() {
        instance = this;

        boardManager = FindObjectOfType<BoardManager>();
        if (!boardManager) 
        {
            GameObject newObj = (GameObject)Instantiate(Resources.Load("Tower of Hanoi System"));
            boardManager = newObj.GetComponent<BoardManager>();
        }

        ringManager = FindObjectOfType<RingManager>();
        if (!boardManager) 
        {
            GameObject newObj = (GameObject)Instantiate(Resources.Load("Tower of Hanoi System"));
            ringManager = newObj.GetComponent<RingManager>();
        }
    }

    [SerializeField] BoardManager boardManager;
    public BoardManager BoardManager { get => boardManager; }

    [SerializeField] RingManager ringManager;
    public RingManager RingManager { get => ringManager; }
}
