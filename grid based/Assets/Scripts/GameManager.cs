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

    private void Update() {
        LevelEnd();
    }

    private void LevelStart() {
        OnLevelStart();
    }
        
    private void OnLevelStart() {
        levelFinished = false;
        levelPrepared = false;
        MainCamera.orthographicSize = PrepareLevel.SetCameraSize();
        SetTiles();
        Invoke("MovePlayerToGrid", 1.25F);
    }

    private void LevelEnd() {
        if (levelPrepared && TilesManager.TilesLeft.Count == 0) {
            levelFinished = true;
        }
        if (levelFinished) {
            Invoke("OnLevelEnd", 2F);
        }
    }
    private void OnLevelEnd() {
        levelFinished = true;
        levelPrepared = false;
        levelIndex++;
        MovePlayerOffScreen();
        MoveTilesOffScreen();

    }

    private void SetTiles() {
        for (int i = 0; i < PrepareLevel.PreparedTilesPositions.Count; i++) {
            Transform tile = TilesManager.PreSpawnedTiles[i];
            tile.transform.localPosition =
                new Vector2(PrepareLevel.PreparedTilesPositions[i].x, PrepareLevel.PreparedTilesPositions[i].y);
            tile.gameObject.GetComponent<Tile>().AddToLists();
        }
        ScaleTiles();
        levelPrepared = true;
    }

    private void ScaleTiles() {
        Debug.Log("Scale");
        foreach (Transform tile in TilesManager.Tiles) {
            tile.gameObject.GetComponent<Tile>().Scale();
        }
    }

    private void MovePlayerToGrid() {
        playerTile.gameObject.GetComponent<PlayerTile>().MoveToGrid(new Vector2(PrepareLevel.SetPlayerPosition().x, PrepareLevel.SetPlayerPosition().y));
    }

    private void MovePlayerOffScreen() {
        playerTile.gameObject.GetComponent<PlayerTile>().MoveOffScreen();
    }

    private void MoveTilesOffScreen() {
        ScaleTiles();
        foreach (Transform tile in TilesManager.Tiles) {
            tile.gameObject.GetComponent<Tile>().MoveToOffScreenPos();
            
        }
    }
    
    IEnumerator WaitForSeconds(float time)
    {
        
        yield return new WaitForSeconds(time);

    }
    
}
