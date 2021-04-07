using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-100)]
public class GameManager : Singleton<GameManager> {
    
    #region References
    [SerializeField] InputManager inputManager;
    public TilesManager TilesManager;
    public Camera MainCamera;
    public Colors Colors;
    public PrepareLevel PrepareLevel;
    public GameObject PlayerTilePrefab;
    [SerializeField] private GameObject tilePrefab;
    #endregion

    #region Fields and properties

    private int levelIndex = 1;
    private bool levelPrepared = false;
    private bool levelFinished = false;

    public int LevelIndex {
        get { return levelIndex; }
    }
    public bool LevelPrepared {
        get { return levelPrepared; }
        set { levelPrepared = value; }
    }
    public bool LevelFinished {
        get { return levelFinished; }
        set { levelFinished = value; }
    }
    
    #endregion
    
    #region Methods
    public override void Awake() { base.Awake(); }
    
    private void OnLevelStart(){
        
    }

    private void OnLevelEnd(){
    
    }
    #endregion

    

}
