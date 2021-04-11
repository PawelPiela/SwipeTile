using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[DefaultExecutionOrder(-100)]
public class GameManager : Singleton<GameManager> {
    
    [SerializeField] InputManager inputManager;
    public TilesManager TilesManager;
    public Camera MainCamera;
    public Colors Colors;
    public PrepareLevel PrepareLevel;
    [SerializeField] private Transform playerTile;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private TextMeshProUGUI textObj;

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
        SetTiles();
        ScaleTilesUp();
        Invoke("MovePlayerToGrid", 1.25F);
    }

    private void LevelEnd() {
        
    }
    private void OnLevelEnd(){
    
    }

    private void SetTiles() {
        for (int i = 0; i < PrepareLevel.PreparedTilesPositions.Count; i++) {
            Transform tile = TilesManager.PreSpawnedTiles[i];
            tile.transform.localPosition =
                new Vector2(PrepareLevel.PreparedTilesPositions[i].x, PrepareLevel.PreparedTilesPositions[i].y);
            tile.gameObject.GetComponent<Tile>().AddToLists();
        }
    }

    private void ScaleTilesUp() {
        foreach (Transform tile in TilesManager.Tiles) {
            tile.gameObject.GetComponent<Tile>().ScaleUP();
        }
    }

    private void MovePlayerToGrid() {
        playerTile.transform.GetComponent<PlayerTile>().MoveToGrid(new Vector2(PrepareLevel.SetPlayerPosition().x, PrepareLevel.SetPlayerPosition().y));
    }
   
}
