using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private List<Color> colors = new List<Color>();
   
    private Color _color;
    void Awake() {
        gameManager = GameManager.Instance;
        SetColor();
    }

    private void SetColor(){
        _color = colors[Random.Range(0, colors.Count)];
        SetBackgroundColor();
    }
    private void SetBackgroundColor(){
        gameManager.MainCamera.backgroundColor = _color;
    }

    public Color SetPlayerColor() {
        return _color;
    }

}
