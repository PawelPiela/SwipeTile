using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorTile : MonoBehaviour
{
    private EditorTilesManager editorTilesManager;
    private void Awake() {
        editorTilesManager = transform.GetComponent<EditorTilesManager>();
    }
    

}
