using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    // Assigns number of rings
    [Range(3, 10)]
    [SerializeField] private int maxNumberOfRings;
    public int MaxNumberOfRings { get => maxNumberOfRings; }

    // List of all rings
    [SerializeField] private List<Ring> listOfAllRings;
    public List<Ring> ListOfAllRings { get => listOfAllRings; }

    [SerializeField] private int largestPossibleRingSize = 5;
    [SerializeField] private int smallestPossibleRingSize = 2;

    [SerializeField] private float generalRingHeight = .2f;

    [SerializeField] private float yOffsetPerRing = .35f;
    public float YOffsetPerRing { get => yOffsetPerRing; }

    [SerializeField] private List<Color> availableRingColors;
    public List<Color> AvailableRingColors { get => availableRingColors; }

    private void Start() {
        CreateRings();
        PositionRings();
        AdjustRingSizes();
        AssignRingColors();
    }

    // Spawns the rings
    private void CreateRings()
    {
        for (int i = 0; i < maxNumberOfRings; i++)
        {
            GameObject spawnObj = Instantiate(Resources.Load("Ring")) as GameObject;
            Ring spawnedRing = spawnObj.GetComponent<Ring>();
            listOfAllRings.Add(spawnedRing);

            GameManager.Instance.BoardManager.StartingPeg.CurrentSetOfRings.Push(listOfAllRings[i]);
            listOfAllRings[i].RespectivePeg = GameManager.Instance.BoardManager.StartingPeg;
        }
    }

    // Place rings on their designated spot
    private void PositionRings()
    {
        if (ListOfRingsIsEmpty()) return;

        for (int i = 0; i < maxNumberOfRings; i++)
        {
            Vector3 assignedPosition = new Vector3(0, yOffsetPerRing * (i+1));
            assignedPosition.z = GameManager.Instance.BoardManager.StartingPeg.transform.position.z;
            listOfAllRings[i].transform.position = assignedPosition;
        }
    }

    // Adjust sizes of the rings
    private void AdjustRingSizes()
    {
        if (ListOfRingsIsEmpty()) return;

        for (int i = 0; i < maxNumberOfRings; i++)
        {
            float ringSizeDecrement = 
                (largestPossibleRingSize - smallestPossibleRingSize) * 1f / (maxNumberOfRings - 1f);

            listOfAllRings[i].RingSize = largestPossibleRingSize - (i * ringSizeDecrement);

            Vector3 assignedScale = 
                new Vector3(listOfAllRings[i].RingSize, generalRingHeight, listOfAllRings[i].RingSize);
            
            listOfAllRings[i].transform.localScale = assignedScale;
        }
    }

    // Assigns colors for the rings
    private void AssignRingColors()
    {
        if (ListOfRingsIsEmpty()) return;

        for (int i = 0; i < maxNumberOfRings; i++)
        {
            listOfAllRings[i].RingColor =  availableRingColors[i % availableRingColors.Count];   
        } 
    }

    // Assign Rings to Starting Peg
    private void AssignRingsToStartingPeg()
    {
        if (ListOfRingsIsEmpty()) return;

        for (int i = 0; i < maxNumberOfRings; i++)
        {
            GameManager.Instance.BoardManager.StartingPeg.CurrentSetOfRings.Push(listOfAllRings[i]);
            listOfAllRings[i].RespectivePeg = GameManager.Instance.BoardManager.StartingPeg;
        }
    }

    // Checks if List of all rings is still empty
    private bool ListOfRingsIsEmpty()
    {
        if (listOfAllRings.Count <= 0) {
            Debug.LogWarning("List of Rings is empty", this); 
            return true;
        }

        else return false;
    }
}
