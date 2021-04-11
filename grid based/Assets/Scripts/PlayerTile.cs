using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerTile : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform movePoint;
    [SerializeField] private TilesManager tilesManager;
    private SpriteRenderer spriteRenderer;
    
    private bool isMoving = false;
    private Vector3 direction = Vector3.zero;
    private Vector3 targetPos;
    [SerializeField] private Vector2 offScreen; 
    public int moveCount = 0;

    private void Awake() {
        transform.position = new Vector2(offScreen.x, offScreen.y);
        gameManager = GameManager.Instance;
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
    }

    private void Start() {
        transform.localScale = new Vector3(0.6F, 0.6F, 1F);
        spriteRenderer.color = gameManager.Colors.SetPlayerColor();

    }
    private void Update() {
        MenageMovement();
    }
    private void MenageMovement() {
        TileMovement();
        MovementInput();
    }

    private void TileMovement() {
        if (direction != Vector3.zero) {
            targetPos = SetNextWaypoint(direction);
            isMoving = true;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPos.x, targetPos.y, targetPos.z), moveSpeed * Time.deltaTime);
            if (transform.position == movePoint.transform.position) {
                isMoving = false;
                direction = Vector3.zero;
            }
        }
    }

    private Vector3 SetNextWaypoint(Vector3 direction) {
        bool isMoveFinished = false;
        while (!isMoveFinished) {
            Vector3 prevPos = movePoint.transform.position;
            movePoint.transform.position = movePoint.transform.position + new Vector3(direction.x, direction.y, direction.z);
            if (tilesManager.Tiles.Find(tilePos => tilePos.position == movePoint.transform.position)) {
                targetPos = movePoint.transform.position;
            } else {
                movePoint.transform.position = new Vector3(prevPos.x, prevPos.y, prevPos.z);
                isMoveFinished = true;
            }
        }
        return targetPos;
    }
    private void MovementInput() { 
        if (isMoving) {
            SwipeDetection.SwipedDirection = direction;
        }
        if (!isMoving) {
            direction = SwipeDetection.SwipedDirection;
        }
    }

    public void MoveToGrid(Vector2 position) {
        transform.localPosition = new Vector2(position.x, position.y);
        RemoveParentFromMovePoint();
    }

    public void MoveOffScreen() {
        SetParentToMovePoint();
        movePoint.transform.localPosition = Vector2.zero;
        transform.position = new Vector2(offScreen.x, offScreen.y);
    }

    public void RemoveParentFromMovePoint() {
        movePoint.transform.position = transform.position;
        movePoint.transform.parent = null;
    }
    public void SetParentToMovePoint() {
        movePoint.transform.position = transform.position;
        movePoint.transform.parent = this.transform;
    }
}
