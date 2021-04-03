using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGrid : MonoBehaviour
{
    [SerializeField] private GameObject EditorTilePrefab;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform TilesParent;
    [SerializeField] private List <Vector2Int> GridSizes = new List<Vector2Int>();
    [SerializeField] private List<Vector2Int> positions = new List<Vector2Int>();
    
    
    void Awake() {
        //GetGridSize();
        //PopulateGrid();
    }
    // private Vector2Int GetGridSize() {
    //     Vector2Int size;
    //     
    //     return size;
    // }
    // private void PopulateGrid() {
    //     int xPos = GetGridSize().x / 2;
    //     int yPos = GetGridSize().y / 2;
    //     for (int i = -xPos; i <= xPos; i++) {
    //         for (int j = -yPos; j <= yPos; j++) {
    //             //positions.Add(new Vector2Int(i,j));
    //             var tile = Instantiate(EditorTilePrefab, new Vector2(i, j),
    //                 Quaternion.identity, TilesParent) as GameObject ;
    //             tile.transform.localPosition = new Vector2(i, j);
    //         }
    //     }
    // }
}