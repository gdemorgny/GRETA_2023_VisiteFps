using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangeColor : MonoBehaviour, IUsableObject
{
    [SerializeField] private Color[] _colors;
    private MeshRenderer _renderer;
    private int _actualColor = -1;
    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        ChangeColor();
    }

    public void UseObject() { ChangeColor(); }

    private void ChangeColor()
    {
        _actualColor++;
        if(_actualColor >= _colors.Length)
        {
            _actualColor = 0;
        }
        _renderer.material.SetColor("_BaseColor",_colors[_actualColor]); 
    }

}