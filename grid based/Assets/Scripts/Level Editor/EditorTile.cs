using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorTile : MonoBehaviour
{
    
    [SerializeField] private EditorTilesManager editorTilesManager;
    
    private SpriteRenderer spriteRenderer;
    private Color defaultColor = Color.white;
    private Color clickedColor = Color.red;

    private bool addedToList = false;
    public bool AddedToList {
        get { return addedToList; }
    }
    
    private void Awake() {
        
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = defaultColor;
        editorTilesManager.EditorTiles.Clear();
    }
    public void OnClick() {
        if (!addedToList) {
            addedToList = true;
            editorTilesManager.EditorTiles.Add(this.transform);
            spriteRenderer.color = clickedColor;
        }

        else if (addedToList) {
            addedToList = false;
            editorTilesManager.EditorTiles.Remove(this.transform);
            spriteRenderer.color = defaultColor;
        }
    }
}
