using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour {
    private TilesManager tilesManager;
    private SpriteRenderer spriteRenderer;
    private GameManager gameManager;
    [SerializeField] private Vector3 finalScale;
    [SerializeField] private Vector2 scalingTimeRange;
    private Vector2Int offScreenPos = new Vector2Int(-100, 0);
    private bool isScaledUp;

    private void Awake() {
        gameManager = GameManager.Instance;
        tilesManager = gameManager.TilesManager.gameObject.GetComponent<TilesManager>();
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        MoveToOffScreenPos();
        isScaledUp = false;
    }

    public void Scale() {
        float scalingTime = Random.Range(scalingTimeRange.x, scalingTimeRange.y);
        Vector3 startScale = Vector3.zero;
        if (!isScaledUp) {
            StartCoroutine(ScaleOverTime(scalingTime, startScale, finalScale));
            isScaledUp = true;
        }
        else if (isScaledUp) {
            StartCoroutine(ScaleOverTime(scalingTime, finalScale, startScale));
            isScaledUp = false;
        }
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
    

    public void AddToLists() {
        tilesManager.Tiles.Add(this.transform);
        tilesManager.TilesLeft.Add(this.transform);
    }
    private void RemoveTileFromList() {
        tilesManager.TilesLeft.Remove(this.transform);
    }

    public void RemoveFromLists() {
        tilesManager.Tiles.Remove(this.transform);
        tilesManager.TilesLeft.Remove(this.transform);
    }

    IEnumerator ScaleOverTime(float time, Vector3 startScale, Vector3 finalScale)
    {
        
        float currentTime = 0.0f;
        do
        {
            transform.localScale = Vector3.Lerp(startScale, finalScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);
    }

    public void MoveToOffScreenPos() {
        transform.position = new Vector2(offScreenPos.x, offScreenPos.y);
    }
    
}
