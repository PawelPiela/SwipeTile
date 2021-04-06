using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    
    #region References
    [SerializeField] InputManager inputManager;
    [SerializeField] public TilesManager tilesManager;
    [SerializeField] public Camera mainCamera;
    [SerializeField] public PrepareLevel prepareLevel;
    #endregion

    #region Fields
    public bool LevelPrepared = false;
    public bool LevelFinished = false;
    #endregion

    public override void Awake() {
        base.Awake();
        
    }
    
    private void OnLevelStart(){
        
    }

    private void OnLevelEnd(){
    
    }

    


    

}
