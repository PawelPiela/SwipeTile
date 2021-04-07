using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PrepareLevel : MonoBehaviour
{
    private GameManager gameManager;
    
    private StreamReader streamReader;
    private string levelsDirectory = Application.streamingAssetsPath + "/Levels";
    
    
    private void Awake() {
        gameManager = GameManager.Instance;
    }

    public void ReadLevelFromTxt(int levelIndex) {
        string levelFileName = (levelsDirectory + "/Level" + levelIndex + ".txt");
        
    }
    
}
