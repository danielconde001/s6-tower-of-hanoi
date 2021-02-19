using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughUnderBoard : MonoBehaviour
{
    [SerializeField] private GameObject board;
    [SerializeField] private Material seeThroughMaterial;
    [SerializeField] private Material defaultMaterial;
    private Color defaultColor;
    private Renderer _renderer;

    private void Awake() {
        this._renderer = GetComponent<Renderer>();
        if (!board) board = GameObject.Find("Board");
        
    }

    private void Start() {
        this.defaultColor = this._renderer.material.color;
        this.seeThroughMaterial.SetColor("See-Through Color", this.defaultColor);
    }

    private void Update() {
        if (ObjectIsUnderBoard()) SeeThrough();
        else if (ObjectIsUnderBoard()) ReturnToDefaultMaterial();
    }

    public void SeeThrough() {
        this._renderer.material = seeThroughMaterial;
        this.seeThroughMaterial.SetColor("See-Through Color", this.defaultColor);
    }

    public void ReturnToDefaultMaterial() {
        this._renderer.material = defaultMaterial;
        this._renderer.material.color = defaultColor;
    }

    private bool ObjectIsUnderBoard()
    {
        return board.transform.position.y > transform.position.y;
    }
}
