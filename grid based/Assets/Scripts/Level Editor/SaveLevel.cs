using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLevel : MonoBehaviour
{
    [SerializeField] private EditorTilesManager editorTilesManager;
    [SerializeField] private CameraSize cameraSize;
    private string levelsDirectory = Application.streamingAssetsPath + "/Levels";
    private FileStream fileStream;
    private StreamWriter streamWriter;

    public void OnButtonClick() {
        if (editorTilesManager.SelectedTiles.Count != 0 && SetPlayerPosition.SelectedPlayerPos != null) {
            CreateLevelFile(GetLevelIndex());
            WriteTilesPositionsToFile();
        }
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
        streamWriter.WriteLine(cameraSize.GetCameraSize().ToString());
        streamWriter.WriteLine(SetPlayerPosition.SelectedPlayerPos.localPosition.x + "," +
                               SetPlayerPosition.SelectedPlayerPos.localPosition.y);
        foreach (Transform tile in editorTilesManager.SelectedTiles) {
            string position = (tile.transform.localPosition.x + "," + tile.transform.localPosition.y);
            streamWriter.WriteLine(position);
        }
        streamWriter.Close();
    }
}