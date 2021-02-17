using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private Ring currentRing;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;    
        bool somethingHit = 
            (Physics.Raycast(ray, out hit, 100f)) && hit.collider.GetComponent<Ring>();
        
        if (Input.GetMouseButton(0) && somethingHit)
        {
            
        }      
    }
}
