using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    [SerializeField] private EditorTilesManager editorTilesManager;

    public void PrintAllTransforms() {
        Debug.Log(editorTilesManager.SelectedTiles.Count);
        foreach (Transform tile in editorTilesManager.SelectedTiles) {
            Debug.Log(tile.transform.name);
        }
        
    }
}
