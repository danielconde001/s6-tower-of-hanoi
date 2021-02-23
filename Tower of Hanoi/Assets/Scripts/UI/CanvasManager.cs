using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal enum CanvasType
{

}

public sealed class CanvasManager : MonoBehaviour
{
    [SerializeField] private KeyCode backKey;

    [SerializeField] private CanvasType canvasType;
}
