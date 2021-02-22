using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Condition : MonoBehaviour
{
    protected abstract bool CheckCondition();
    protected bool conditonIsMet = false;
    [SerializeField] protected UnityEvent OnConditionMet;

    protected void Update() {
        
        if (CheckCondition() && !conditonIsMet) {
            OnConditionMet.Invoke();
            conditonIsMet = true;
        }
    }
}
