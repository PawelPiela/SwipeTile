using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Colors : MonoBehaviour
{
    [SerializeField] private List<Color> colors = new List<Color>();
    private Color _color;
    
    private void Start(){
        _color = colors[Random.Range(0, colors.Count)];
    }
    public Color GetColor() {
        return _color;
    }

}
