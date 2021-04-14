using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DataManager : MonoBehaviour
{
    [SerializeField] private Colors colors;
    [SerializeField] private PrepareLevel prepareLevel;
    [SerializeField] private Camera cameraMain;

    void Start() {
        cameraMain.backgroundColor = colors.GetColor();
        Debug.Log(Level.LevelIndex);
        prepareLevel.ReadLevelFromTxt(Level.LevelIndex);
        
        Level.SetTilesPositions(prepareLevel.GetTilesPositions());
        Level.SetPlayerPosition(prepareLevel.GetPlayerPosition());
        Level.SetCameraSize(prepareLevel.GetCameraSize());
        Level.SetColor(colors.GetColor());
        //StartCoroutine(EndLevelCoroutine());
        SceneManager.LoadScene("Level");
    }   
    
    private IEnumerator EndLevelCoroutine() {
        yield return new WaitForSeconds(0.5F);
        SceneManager.LoadScene("Level");
    }
    
}
