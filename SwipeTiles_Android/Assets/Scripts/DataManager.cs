using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DataManager : MonoBehaviour {
    [SerializeField] private Colors colors;
    [SerializeField] private PrepareLevel prepareLevel;
    [SerializeField] private Camera cameraMain;

    void Start() {
        cameraMain.backgroundColor = colors.GetColor();
        prepareLevel.ReadLevelFromTxt(Level.LevelIndex);
        if(prepareLevel.LevelExists){
            Level.SetTilesPositions(prepareLevel.GetTilesPositions());
            Level.SetPlayerPosition(prepareLevel.GetPlayerPosition());
            Level.SetCameraSize(prepareLevel.GetCameraSize());
            Level.SetColor(colors.GetColor());
            SceneManager.LoadScene("Level");
        }
        else {
            Level.LevelIndex = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
