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

    private void Awake() {
        gameManager = GameManager.Instance;
    }

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
         //yield return new WaitForSeconds(1);
         SetTiles();
         yield return new WaitForSeconds(1.5F);
         gameManager.LevelPrepared = true;
    }
    private void StartLevel() {
        //SetTiles();
        StartCoroutine(StartLevelCoroutine());
    }
    private IEnumerator EndLevelCoroutine() {
        yield return new WaitForSeconds(1);
        ScaleTiles();
    }
    private void EndLevel() {
        //ScaleTiles();
        StartCoroutine(EndLevelCoroutine());
    }

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
    
}
