using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DraggableManager : MonoBehaviour
{

    List<Draggable> allDraggables = new List<Draggable>();

    public void ScanForDraggables()
    {
        allDraggables.Clear();
        
        Draggable[] draggables = FindObjectsOfType<Draggable>();
        
        for (int i = 0; i < draggables.Length; i++)
        {
            allDraggables.Add(draggables[i]);
        }
    }

    public void EnableAllDraggables()
    {
        for (int i = 0; i < allDraggables.Count; i++)
        {
            allDraggables[i].gameObject.SetActive(true);
        }
    }

    public void DisableAllDraggables()
    {  
        for (int i = 0; i < allDraggables.Count; i++)
        {
            allDraggables[i].gameObject.SetActive(false);
        }
    }

    
}
