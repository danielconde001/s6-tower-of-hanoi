﻿using System.Collections;
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
            listOfAllRings[i].DesignatedPosition = assignedPosition;
            listOfAllRings[i].DropPosition = listOfAllRings[i].DesignatedPosition;
            listOfAllRings[i].transform.position = listOfAllRings[i].DesignatedPosition;
        }
    }

    // Adjust sizes of the rings
    private void AdjustRingSizes()
    {
        if (ListOfRingsIsEmpty()) return;

        for (int i = 0; i < maxNumberOfRings; i++)
        {
            float a = (largestPossibleRingSize - smallestPossibleRingSize);
            float b = 1f / (maxNumberOfRings - 1f);
            float ringSizeDecrement = a * b;

            listOfAllRings[i].RingSize = largestPossibleRingSize - (i * ringSizeDecrement);

            Vector3 assignedScale;
            assignedScale.x = listOfAllRings[i].RingSize;
            assignedScale.y = generalRingHeight;
            assignedScale.z = assignedScale.x;
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


#region Empty List Checker
    // Checks if List of all rings is still empty
    private bool ListOfRingsIsEmpty()
    {
        if (listOfAllRings.Count <= 0) {
            Debug.LogWarning("List is empty", this); 
            return true;
        }

        else return false;
    }
#endregion
}
