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
    //      get { return instance; }
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
    
    private int levelIndex;
    public int LevelIndex {
        get {
            return levelIndex;
        }
    }
    
    private bool levelPrepared = false;
    private bool levelFinished = false;

    public void Awake() {
        base.Awake();
        level = Level.Instance;
        MainCamera.orthographicSize = 2;
    }
    
    // private void OnEnable() {
    //     SceneManager.sceneLoaded += SceneLoaded;
    // }
    //
    //
    // private void OnDisable() {
    //     SceneManager.sceneLoaded -= SceneLoaded;
    // }
    //
    // private void SceneLoaded(Scene scene, LoadSceneMode mode) {
    //     if (scene.isLoaded) {
    //         MainCamera.orthographicSize = 2;
    //         levelFinished = false;
    //         levelPrepared = false;
    //         MainCamera.orthographicSize = PrepareLevel.SetCameraSize();
    //         if (StartEvent != null) StartEvent();
    //         levelText.text = (LevelIndex).ToString();
    //     }
    // }
    
    public bool LevelPrepared {
        get { return levelPrepared; }
        set { levelPrepared = value; }
    }
    public bool LevelFinished {
        get { return levelFinished; }
        set { levelFinished = value; }
    }
    //OnLevelLoadedFromFile()
    public void Start() {
        levelFinished = false;
        levelPrepared = false;
        levelIndex = Level.LevelIndex;
        if(StartEvent != null) StartEvent();
        MainCamera.orthographicSize = PrepareLevel.SetCameraSize();
        levelText.text = (LevelIndex).ToString();
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
        SceneManager.LoadScene("Level");
    }
    
    public void RestartLevel() {
        
    }
}
