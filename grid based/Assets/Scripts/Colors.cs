using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Colors : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Transform playerTile;
    [SerializeField] private List<Color> colors = new List<Color>();
   
    private Color _color;
    void Awake() {
        gameManager = GameManager.Instance;
    }

    private void OnEnable() {
        GameManager.StartEvent += SetColor;
    }

    private void OnDisable() {
        GameManager.StartEvent += SetColor;
    }

    private void SetColor(){
        _color = colors[Random.Range(0, colors.Count)];
        SetBackgroundColor();
        SetPlayerColor();
    }
    private void SetBackgroundColor(){
        gameManager.MainCamera.backgroundColor = _color;
    }

    private void SetPlayerColor() {
        playerTile.gameObject.GetComponent<SpriteRenderer>().color = _color;
    }

}
