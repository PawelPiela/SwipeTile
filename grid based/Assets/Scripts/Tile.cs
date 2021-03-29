using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    private TilesManager tilesManager;
    private SpriteRenderer spriteRenderer;


    private void Awake() {
        tilesManager = gameObject.GetComponentInParent<TilesManager>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        tilesManager.Tiles.Add(this.transform);
        tilesManager.TilesLeft.Add(this.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && spriteRenderer.color != Color.white) {
            RemoveTileFromList();
            Invoke("ChangeColor", 0.1f);
        }
    }

    private void ChangeColor() {
        spriteRenderer.color = Color.white;
    }
    private void RemoveTileFromList() {
        tilesManager.TilesLeft.Remove(this.transform);
    }

}
