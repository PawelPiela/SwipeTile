using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour {
    private TilesManager tilesManager;
    private SpriteRenderer spriteRenderer;
    private GameManager gameManager;
    [SerializeField] private Vector3 finalScale;
    [SerializeField] private Vector2 scalingTimeRange;

    private void Awake() {
        gameManager = GameManager.Instance;
        tilesManager = gameManager.TilesManager.gameObject.GetComponent<TilesManager>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        tilesManager.Tiles.Add(this.transform);
        tilesManager.TilesLeft.Add(this.transform);
        transform.localScale = new Vector3(0.95F, 0.95F, 1F);
    }

    private void Start() {
        float scalingTime = Random.Range(scalingTimeRange.x, scalingTimeRange.y);
        StartCoroutine(ScaleOverTime(scalingTime));
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

    IEnumerator ScaleOverTime(float time)
    {
        Vector3 startScale = Vector3.zero;
        float currentTime = 0.0f;
        do
        {
            transform.localScale = Vector3.Lerp(startScale, finalScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }
    
}
