using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-100)]
public class GameManager : Singleton<GameManager> {
    
    [SerializeField] InputManager inputManager;
    public TilesManager TilesManager;
    public Camera MainCamera;
    public Colors Colors;
    public PrepareLevel PrepareLevel;
    public GameObject PlayerTilePrefab;
    [SerializeField] private GameObject tilePrefab;

    private int levelIndex = 1;
    private bool levelPrepared = false;
    private bool levelFinished = false;

    
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
    
    
    public override void Awake() { base.Awake(); }


    private void Start() {
        Invoke("LevelStart", 1F);
    }

    private void LevelStart() {
        OnLevelStart();
    }
        
    private void OnLevelStart() {
        levelFinished = false;
        levelPrepared = false;
        MainCamera.orthographicSize = PrepareLevel.SetCameraSize();
        SpawnTiles();
        Invoke("SpawnPlayer", 1.25F);

    }

    private void LevelEnd() {
        
    }
    private void OnLevelEnd(){
    
    }

    private void SpawnTiles() {
        foreach (Vector2Int pos in PrepareLevel.PreparedTilesPositions) {
            Instantiate(tilePrefab, new Vector2(pos.x, pos.y), Quaternion.identity, TilesManager.transform);
        }
    }

    private void SpawnPlayer() {
        Vector2 playerPos = PrepareLevel.SetPlayerPosition();
        Instantiate(PlayerTilePrefab, new Vector2(playerPos.x, playerPos.y),Quaternion.identity,TilesManager.transform);
    }
    
    

    

}
