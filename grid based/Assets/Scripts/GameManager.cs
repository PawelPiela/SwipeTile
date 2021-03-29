using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    
    #region References
    [SerializeField] InputManager inputManager;
    [SerializeField] TilesManager tilesManager;
    #endregion

    #region Fields
    public bool isLevelReady = false;
    private int levelCount;
    #endregion

    public override void Awake() {
        base.Awake();
    }

    private void OnLevelStart(){

    }

    private void OnLevelEnd(){

    }




    

}
