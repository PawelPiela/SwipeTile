using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[DefaultExecutionOrder(-100)]
public class GameManager : Singleton<GameManager> {
    
    public delegate void LevelStart();
    public static event LevelStart StartEvent;

    public delegate void LevelEnd();
    public static event LevelEnd EndEvent;

    public delegate void LevelRestart();
    public static event LevelRestart RestartEvent;
    
    
    [SerializeField] InputManager inputManager;
    public TilesManager TilesManager;
    public Camera MainCamera;
    public Colors Colors;
    public PrepareLevel PrepareLevel;
    
  

    public int levelIndex = 1;
    private bool levelPrepared = false;
    private bool levelFinished = false;

    public override void Awake() {
        base.Awake();
        MainCamera.orthographicSize = 2;
    }
    
    public int LevelIndex {
        get { return levelIndex; }
    }
    public bool LevelPrepared {
        get { return levelPrepared; }
        set { levelPrepared = value; }
    }
    public bool LevelFinished {
        get { return levelFinished; }
        set { levelFinished = value; }
    }
    
    private void Start() {
        levelFinished = false;
        levelPrepared = false;
        MainCamera.orthographicSize = PrepareLevel.SetCameraSize();
        if(StartEvent != null) StartEvent();
        
    }

    private void Update() {
        EndLevel();
    }
    
    private void EndLevel() {
        if (TilesManager.TilesLeft.Count == 0 && levelPrepared && !levelFinished) {
            if(EndEvent != null) EndEvent();
            levelFinished = true;
        }
    }

    public void RestartLevel() {
        
    }
        
    
    
}
