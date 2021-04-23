using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{

    private GameManager gameManager;
    public List<Transform> Tiles = new List<Transform>();
    public List<Transform> TilesLeft = new List<Transform>();
    public List<Transform> PreSpawnedTiles = new List<Transform>();

    private void Awake() { gameManager = GameManager.Instance; }

    private void OnEnable() {
        GameManager.StartEvent += StartLevel;
        GameManager.EndEvent += EndLevel;
        GameManager.RestartEvent += EndLevel;
    }

    private void OnDisable() {
        GameManager.StartEvent -= StartLevel;
        GameManager.EndEvent -= EndLevel;
        GameManager.RestartEvent -= EndLevel;
    }

     private IEnumerator StartLevelCoroutine() {
         SetTiles();
         yield return new WaitForSeconds(1.5F);
         gameManager.LevelPrepared = true;
    }
     private IEnumerator EndLevelCoroutine() {
        yield return new WaitForSeconds(1);
        ScaleTiles();
        yield return new WaitForSeconds(1.4F);
        MoveOffScreen();
    }
    private void StartLevel() { StartCoroutine(StartLevelCoroutine()); }
    private void EndLevel() { StartCoroutine(EndLevelCoroutine()); }

    private void SetTiles() {
        for (int i = 0; i < Level.GetTilesPositions().Count; i++) {
            Transform tile = PreSpawnedTiles[i];
            tile.transform.localPosition =
                new Vector2(Level.GetTilesPositions()[i].x, Level.GetTilesPositions()[i].y);
            tile.gameObject.GetComponent<Tile>().AddToLists();
        }
        ScaleTiles();
    }
    
    private void ScaleTiles() {
        foreach (Transform tile in Tiles) {
            tile.gameObject.GetComponent<Tile>().Scale();
        }
    }

    private void MoveOffScreen() {
        foreach (Transform tile in Tiles) {
            tile.transform.position = new Vector2(-100, 0);
        }
    }
}
