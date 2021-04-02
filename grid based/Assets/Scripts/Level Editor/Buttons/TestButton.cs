using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    [SerializeField] private EditorTilesManager editorTilesManager;

    public void PrintAllTransforms() {
        Debug.Log(editorTilesManager.EditorTiles.Count);
        foreach (Transform tile in editorTilesManager.EditorTiles) {
            Debug.Log(tile.transform.name);
        }
        
    }
}
