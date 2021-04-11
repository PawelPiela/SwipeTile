using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
[DefaultExecutionOrder(-100)]
public class GameManager : Singleton<GameManager> {
    
    // private static GameManager instance;
    // public static GameManager Instance {
    //     get { return instance; }
    // }
    
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
    public Colors Colors;
    public PrepareLevel PrepareLevel;
    [SerializeField] private TextMeshProUGUI levelText;
    
    
    private bool levelPrepared = false;
    private bool levelFinished = false;

    public override void Awake() {
        base.Awake();
        level = Level.Instance;
        MainCamera.orthographicSize = 2;
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
        levelText.text = (level.LevelIndex).ToString();

    }

    private void Update() {
        EndLevel();
    }
    
    private void EndLevel() {
        if (TilesManager.TilesLeft.Count == 0 && levelPrepared && !levelFinished) {
            if(EndEvent != null) EndEvent();
            levelFinished = true;
            level.LevelIndex++;
            StartCoroutine(EndLevelCoroutine());
            
        }
    }

    private IEnumerator EndLevelCoroutine() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Level");
    }
    
    public void RestartLevel() {
        
    }
        
    
    
}
