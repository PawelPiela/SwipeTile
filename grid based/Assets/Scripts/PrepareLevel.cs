using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
[DefaultExecutionOrder(-90)]
public class PrepareLevel : MonoBehaviour
{
    private GameManager gameManager;
    public List<Vector2Int> PreparedTilesPositions = new List<Vector2Int>();
    private List<string> stringList = new List<string>();
    private int cameraSize;
    public Vector2Int playerPosition;
    
    private void Awake() {
        gameManager = GameManager.Instance;
        BetterStreamingAssets.Initialize();
    }

    private void Start() {
        ReadLevelFromTxt(gameManager.LevelIndex);
    }

    private void ReadLevelFromTxt(int levelIndex) {
        // string levelFileName = (levelsDirectory + "/Level" + levelIndex + ".txt");
        // using (StreamReader streamReader = new StreamReader(levelFileName)) {
        //     string line;
        //     while ((line = streamReader.ReadLine()) != null) {
        //         stringList.Add(line);
        //     }
        // }
        
        ///BETTER STREAMING ASSETS////
        string levelFileName = ("/levels"+"/level" + levelIndex + ".txt");
        using (var stream = BetterStreamingAssets.OpenText(levelFileName)) {
            string line;
            while ((line = stream.ReadLine()) != null) {
                stringList.Add(line);
            }
        }
        cameraSize = Convert.ToInt32(stringList[0]);
        playerPosition = GetVector2Int(stringList[1]);
        foreach (string line in stringList.Skip(2)) {
            PreparedTilesPositions.Add(GetVector2Int(line));
        }
    }
    
    
    private Vector2Int GetVector2Int(string line) {
        string[] array = line.Split(',');
        int x = Convert.ToInt32(array[0]);
        int y = Convert.ToInt32(array[1]);
        return new Vector2Int(x, y);
    }

    public int SetCameraSize() {
        return cameraSize;
    }

    public Vector2Int SetPlayerPosition() {
        return playerPosition;
    }

    
    
}
