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
    public GameObject PlayerTilePrefab;
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
        textObj.text = PrepareLevel.PreparedTilesPositions.Count.ToString();
        ScaleTilesUp();
        Invoke("SpawnPlayer", 1.25F);

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

    private void SpawnPlayer() {
        Vector2 playerPos = PrepareLevel.SetPlayerPosition();
        Instantiate(PlayerTilePrefab, new Vector2(playerPos.x, playerPos.y),Quaternion.identity,TilesManager.transform);
    }
    // private void SpawnTiles() {
    //     foreach (Vector2Int pos in PrepareLevel.PreparedTilesPositions) {
    //         Instantiate(tilePrefab, new Vector2(pos.x, pos.y), Quaternion.identity, TilesManager.transform);
    //     }
    // }
}
