using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private List<Color> colors = new List<Color>();
   
    public Color ColorFromList;
    void Awake() {
        gameManager = GameManager.Instance;
        SetColor();
    }

    private void SetColor(){
        ColorFromList = colors[Random.Range(0, colors.Count)];
        SetBackgroundColor();
        //SetPlayerTileColor();
    }
    private void SetBackgroundColor(){
        gameManager.MainCamera.backgroundColor = ColorFromList;
    }
    // private void SetPlayerTileColor(){
    //     gameManager.PlayerTilePrefab.gameObject.GetComponent<SpriteRenderer>().color = ColorFromList;
    // }

}
