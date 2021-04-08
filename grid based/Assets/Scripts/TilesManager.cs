using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{

    private GameManager gameManager;
    public List<Transform> Tiles = new List<Transform>();
    public List<Transform> TilesLeft = new List<Transform>(); 
    

    private void Awake() {
        gameManager = GameManager.Instance;
    }
    
    
}
