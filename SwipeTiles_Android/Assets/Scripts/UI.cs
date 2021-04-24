using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public delegate void RestartLevel();
    public static event RestartLevel OnRestartLevel;
    [SerializeField] private TextMeshProUGUI textObject;
    [SerializeField] private string text;
    private GameManager gameManager;

    private void Awake() {
        gameManager = GameManager.Instance;
    }

    void Start()
    {
        textObject.text = text + (gameManager.LevelIndex);
    }

    
}
