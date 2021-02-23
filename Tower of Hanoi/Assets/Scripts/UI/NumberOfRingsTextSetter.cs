using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TMPro.TMP_Text))]
public sealed class NumberOfRingsTextSetter : MonoBehaviour
{
    private TMPro.TMP_Text numberText;

    private void Awake() {
        numberText = GetComponent<TMPro.TMP_Text>();
    }

    private void Update() {
        numberText.text = GameManager.Instance.RingManager.MaxNumberOfRings.ToString();
    }
}
