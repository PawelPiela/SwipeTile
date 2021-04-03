using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesGrid : MonoBehaviour
{
    [SerializeField] private GameObject EditorTilePrefab;
    [SerializeField] private Transform TilesParent;
    [SerializeField] private CameraSize cameraSize;
    //[SerializeField] private List <Vector2Int> GridSizes = new List<Vector2Int>();
    [SerializeField] private List<GameObject> tiles = new List<GameObject>();

    
     private Vector2Int GetGridSize() {
         int yAxisMultiplier = (int)((cameraSize.GetCameraSize() - 1) / 2);
         return new Vector2Int(cameraSize.GetCameraSize() - 1, cameraSize.GetCameraSize() + yAxisMultiplier);
     }
    private void PopulateGrid() {
        int xPos = GetGridSize().x / 2;
        int yPos = GetGridSize().y / 2;
        for (int i = -xPos; i <= xPos; i++) {
            for (int j = -yPos; j <= yPos; j++) {
                var tile = Instantiate(EditorTilePrefab, new Vector2(i, j),
                    Quaternion.identity, TilesParent) as GameObject ;
                tile.transform.localPosition = new Vector2(i, j);
                tiles.Add(tile.gameObject);
            }
        }
    }
    public void OnGenerateGrid() {
        if (tiles.Count != 0) {
            foreach (var tile in tiles) { 
                Destroy(tile);
            }
            tiles.Clear();
        }
        GetGridSize();
        PopulateGrid();
    }
    
}