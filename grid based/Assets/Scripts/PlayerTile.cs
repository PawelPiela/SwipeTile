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
    //public int moveCount = 0;
    private bool movementEnabled = false;

    private void Awake() {
        transform.position = new Vector2(offScreen.x, offScreen.y);
        gameManager = GameManager.Instance;
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        
    }
    
    private void OnEnable() {
        GameManager.StartEvent += StartLevel;
        GameManager.EndEvent += EndLevel;
        GameManager.RestartEvent += EndLevel;
    }

    private void OnDisable() {
        GameManager.StartEvent -= StartLevel;
        GameManager.EndEvent -= EndLevel;
        GameManager.RestartEvent -= EndLevel;
    }

    private IEnumerator StartLevelCoroutine() {
        yield return new WaitForSeconds(1.75F);
        MoveToGrid();
        yield return new WaitForSeconds(0.5F);
        EnableMovement();

    }
    
    private IEnumerator EndLevelCoroutine() {
        yield return new WaitForSeconds(1);
        MoveOffScreen();
    }
    
    private void StartLevel() { StartCoroutine(StartLevelCoroutine());
    }
    
    private void EndLevel() { StartCoroutine(EndLevelCoroutine());
    }
    
    private void Start() {
        transform.localScale = new Vector3(0.6F, 0.6F, 1F);
        spriteRenderer.color = Level.GetColor();
    }
    private void Update() {
        if(movementEnabled) MenageMovement();
        
    }
    private void MenageMovement() {
        TileMovement();
        MovementInput();
    }

    private void EnableMovement() {
        movementEnabled = true;
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

    private void MoveToGrid() {
        transform.localPosition = new Vector2(Level.GetPlayerPosition().x, Level.GetPlayerPosition().y);
        RemoveParentFromMovePoint();
    }

    private void MoveOffScreen() {
        movePoint.transform.localPosition = Vector2.zero;
        transform.position = new Vector2(offScreen.x, offScreen.y);
    }
    private void RemoveParentFromMovePoint() {
        movePoint.transform.position = transform.position;
        movePoint.transform.parent = null;
    }

}
