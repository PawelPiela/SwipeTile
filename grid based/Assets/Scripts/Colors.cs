using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour {
    [SerializeField] private List<Color> colors = new List<Color>();
    [SerializeField] private Camera mainCamera;
    [SerializeField] private SpriteRenderer playerTileRenderer;
    private Color color;
    void Awake() {
        SetColor();
    }

    private void SetColor(){
        color = colors[Random.Range(0, colors.Count)];
        SetBackgroundColor();
        SetPlayerTileColor();
    }
    private void SetBackgroundColor(){
        mainCamera.backgroundColor = color;
    }
    private void SetPlayerTileColor(){
        playerTileRenderer.color = color;
    }

}
