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
    [SerializeField] private Transform nextMove;
    [SerializeField] private TilesManager tilesManager;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private SwipeDetection swipeDetection;
    
    public bool isMoving = false;
    public Vector3 direction = Vector3.zero;
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
        SwipeDetection.Swiped += TileMove;
    }

    private void OnDisable() {
        GameManager.StartEvent -= StartLevel;
        GameManager.EndEvent -= EndLevel;
        GameManager.RestartEvent -= EndLevel;
        SwipeDetection.Swiped -= TileMove;
    }

    private IEnumerator StartLevelCoroutine() {
        yield return new WaitForSeconds(1.75F);
        MoveToGrid();
        yield return new WaitForSeconds(1F);
        EnableMovement();
    }

    private IEnumerator EndLevelCoroutine() {
        yield return new WaitForSeconds(1);
        MoveOffScreen();
    }

    private void StartLevel() {
        StartCoroutine(StartLevelCoroutine());
    }

    private void EndLevel() {
        StartCoroutine(EndLevelCoroutine());
    }

    private void Start() {
        transform.localScale = new Vector3(0.6F, 0.6F, 1F);
        spriteRenderer.color = Level.GetColor();
    }

    private void Update() {
        if (movementEnabled) MenageMovement();
    }

    private void MenageMovement() {
        //TileMovement();
        MovementInput();
        //TileMove();
    }

    private void EnableMovement() {
        movementEnabled = true;
    }

    private void TileMove() {
        if (direction != Vector3.zero) {
            isMoving = true;
            bool moveEnded = false;
            while (!moveEnded) {
                Vector2 currentPos = movePoint.transform.position;
                nextMove.transform.position = new Vector2((currentPos.x + direction.x), (currentPos.y + direction.y));
                if (tilesManager.Tiles.Find(tilePos => tilePos.transform.position == nextMove.transform.position)) {
                    Vector3 nextPos = movePoint.transform.position + new Vector3(direction.x, direction.y);
                    movePoint.transform.position = nextPos;
                }
                else {
                    moveEnded = true;
                }
            }
            if(isMoving) StartCoroutine(Move());
        }
    }

    private IEnumerator Move() {
        if (direction != Vector3.zero) {
            Vector3 target = movePoint.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x, target.y, target.z),
                moveSpeed * Time.deltaTime);
            if (transform.position == target) {
                direction = Vector3.zero;
                isMoving = false;
                Debug.Log("123");
               
            }
        }
        yield return new WaitForSeconds(5f);
    }
    
    private void MovementInput() {
        if (isMoving) {
            swipeDetection.SwipedDirection = direction;
        }

        if (!isMoving) {
            direction = swipeDetection.SwipedDirection;
        }
    }
    
    // private void TileMovement() {
    //     if (direction != Vector3.zero) {
    //         Debug.Log("direction: " + direction);
    //         targetPos = SetNextWaypoint(direction);
    //         isMoving = true;
    //         transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPos.x, targetPos.y, targetPos.z), moveSpeed * Time.deltaTime);
    //         if (transform.position == movePoint.transform.position) {
    //             isMoving = false;
    //             direction = Vector3.zero;
    //         }
    //     }
    // }

    // private Vector3 SetNextWaypoint(Vector3 direction) {
    //     bool isMoveFinished = false;
    //     while (!isMoveFinished) {
    //         Vector3 prevPos = movePoint.transform.position;
    //         movePoint.transform.position = movePoint.transform.position + new Vector3(direction.x, direction.y, direction.z);
    //         if (tilesManager.Tiles.Find(tilePos => tilePos.position == movePoint.transform.position)) {
    //             targetPos = movePoint.transform.position;
    //         } else {
    //             movePoint.transform.position = new Vector3(prevPos.x, prevPos.y, prevPos.z);
    //             isMoveFinished = true;
    //         }
    //     }
    //     Debug.Log("pos: " + targetPos);
    //     return targetPos;
    // }
    
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