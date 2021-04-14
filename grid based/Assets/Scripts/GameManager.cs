using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
[DefaultExecutionOrder(-100)]
public class GameManager : Singleton<GameManager> {
    
    public delegate void LevelStart();
    public static event LevelStart StartEvent;
    public delegate void LevelEnd();
    public static event LevelEnd EndEvent;
    public delegate void LevelRestart();
    public static event LevelRestart RestartEvent;

    private Level level;
    [SerializeField] InputManager inputManager;
    public TilesManager TilesManager;
    public Camera MainCamera;
    
    private bool levelFinished;
    private bool levelPrepared;
    public bool LevelPrepared {
        get { return levelPrepared; }
        set { levelPrepared = value; }
    }
    private int levelIndex;
    public int LevelIndex {
        get { return levelIndex; }
        set { levelIndex = value; }
    }
    public void Awake() {
        base.Awake();
        MainCamera.orthographicSize = 2;
    }
    
    
    
    public void Start() {
        levelFinished = false;
        levelPrepared = false;
        levelIndex = Level.LevelIndex;
        if(StartEvent != null) StartEvent();
        MainCamera.orthographicSize = Level.GetCameraSize();
        MainCamera.backgroundColor = Level.GetColor();
        
    }

    private void Update() {
        EndLevel();
    }
    private void EndLevel() {
        if (TilesManager.TilesLeft.Count == 0 && levelPrepared && !levelFinished) {
            if (EndEvent != null) {
                EndEvent();
            }
            levelFinished = true;
            Level.LevelIndex++;
            StartCoroutine(EndLevelCoroutine());
        }
    }
    private IEnumerator EndLevelCoroutine() {
        yield return new WaitForSeconds(2.5F);
        SceneManager.LoadScene("LoadingData");
    }
    
    public void RestartLevel() {
        
    }
}
