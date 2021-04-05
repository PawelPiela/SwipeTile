using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLevel : MonoBehaviour
{
    [SerializeField] private EditorTilesManager editorTilesManager;
    private string levelsDirectory = Application.streamingAssetsPath + "/Levels";
    private FileStream fileStream;
    private StreamWriter streamWriter;
    
    public void OnButtonClick() {
        CreateLevelFile(GetLevelIndex());
        WriteTilesPositionsToFile();
    }

    private int GetLevelIndex() {
        DirectoryInfo directory = new DirectoryInfo(levelsDirectory);
        FileInfo[] files = directory.GetFiles("*.txt", SearchOption.TopDirectoryOnly);
        return (files.Length + 1);
    }
    private void CreateLevelFile(int levelIndex) {
        fileStream = File.Create(levelsDirectory + "/Level" + levelIndex + ".txt");
    }

    private void WriteTilesPositionsToFile() {
        streamWriter = new StreamWriter(fileStream);
        foreach (Transform tile in editorTilesManager.SelectedTiles) {
            string position = (tile.transform.localPosition.x + "," + tile.transform.localPosition.y);
            streamWriter.WriteLine(position);
        }
       
        //string playerPosition = 
        streamWriter.Close();
    }
}
