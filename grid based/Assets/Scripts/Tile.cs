using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    private TilesManager tilesManager;
    private SpriteRenderer spriteRenderer;
    private GameManager gameManager;


    private void Awake() {
        gameManager = GameManager.Instance;
        tilesManager = gameManager.TilesManager.gameObject.GetComponent<TilesManager>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        tilesManager.Tiles.Add(this.transform);
        tilesManager.TilesLeft.Add(this.transform);
        transform.localScale = new Vector3(0.95F, 0.95F, 1F);
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
