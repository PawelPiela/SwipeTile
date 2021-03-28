using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    private TilesManager tilesManager;
    private SpriteRenderer spriteRenderer;


    private void Awake() {
        tilesManager = gameObject.GetComponentInParent<TilesManager>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        tilesManager.tiles.Add(this.transform);
        tilesManager.tilesLeft.Add(this.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            ChangeColor();
            RemoveTileFromList();
        }
    }

    private void ChangeColor() {
        spriteRenderer.color = Color.white;
    }
    private void RemoveTileFromList() {
        tilesManager.tilesLeft.Remove(this.transform);
    }

}
