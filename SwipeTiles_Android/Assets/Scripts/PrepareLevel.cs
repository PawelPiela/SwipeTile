using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
public class PrepareLevel : MonoBehaviour {
    private List<Vector2Int> preparedTilesPositions = new List<Vector2Int>();
    private List<string> stringList = new List<string>();
    private int cameraSize;
    public Vector2Int playerPosition;

    private bool levelExists = false;

    public bool LevelExists {
        get { return levelExists; }
    }

    private void Awake() { BetterStreamingAssets.Initialize(); }

    public void ReadLevelFromTxt(int levelIndex) {
        string levelFileName = ("/levels" + "/level" + levelIndex + ".txt");
        if (BetterStreamingAssets.FileExists(levelFileName)) {
            levelExists = true;
            using (var stream = BetterStreamingAssets.OpenText(levelFileName)) {
                string line;
                while ((line = stream.ReadLine()) != null) {
                    stringList.Add(line);
                }
            }
            cameraSize = Convert.ToInt32(stringList[0]);
            playerPosition = GetVector2Int(stringList[1]);
            foreach (string line in stringList.Skip(2)) {
                preparedTilesPositions.Add(GetVector2Int(line));
            }
        }
    }
    private Vector2Int GetVector2Int(string line) {
        string[] array = line.Split(',');
        int x = Convert.ToInt32(array[0]);
        int y = Convert.ToInt32(array[1]);
        return new Vector2Int(x, y);
    }

    public int GetCameraSize() { return cameraSize; }

    public Vector2Int GetPlayerPosition() { return playerPosition; }

    public List<Vector2Int> GetTilesPositions() { return preparedTilesPositions; }


}
