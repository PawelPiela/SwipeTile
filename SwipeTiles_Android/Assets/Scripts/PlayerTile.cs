using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerTile : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform moveToPoint;
    [SerializeField] private Transform nextStepPos;
    [SerializeField] private TilesManager tilesManager;
    [SerializeField] private SwipeDetection swipeDetection;
    private SpriteRenderer spriteRenderer;
    
    private bool isMoving = false;
    private Vector2 direction = Vector2.zero;
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
    }

    private void OnDisable() {
        GameManager.StartEvent -= StartLevel;
        GameManager.EndEvent -= EndLevel;
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
        if (movementEnabled){
            DirectionInput();
            Movement();
        }
    }

    private void EnableMovement() {
        movementEnabled = true;
    }

    private void Movement() {
        if (direction != Vector2.zero) {
            bool moveCalculated = false;
            isMoving = true;
            while (!moveCalculated) {
                Vector2 currentPos = moveToPoint.transform.position;
                nextStepPos.transform.position = new Vector2((currentPos.x + direction.x), (currentPos.y + direction.y));
                if (tilesManager.Tiles.Find(tilePos => tilePos.transform.position == nextStepPos.transform.position)) {
                    Vector3 nextPos = moveToPoint.transform.position + new Vector3(direction.x, direction.y);
                    moveToPoint.transform.position = nextPos;
                }
                else { moveCalculated = true; }
            }  
            Move();  
        }
    }

    private void Move() {
        if (isMoving) {
            Vector3 target = moveToPoint.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x, target.y, target.z), moveSpeed * Time.deltaTime);
            if (transform.position == target && isMoving) {
                Handheld.Vibrate();
                isMoving = false;
            }
        }
    }
    
    private void DirectionInput() {
        if (isMoving) { swipeDetection.SwipedDirection = Vector2.zero; }
        if (!isMoving) { direction = swipeDetection.SwipedDirection; }
    }
    
    private void MoveToGrid() {
        transform.localPosition = new Vector2(Level.GetPlayerPosition().x, Level.GetPlayerPosition().y);
        RemoveParentFromMovePoint();
    }

    private void MoveOffScreen() {
        moveToPoint.transform.localPosition = Vector2.zero;
        transform.position = new Vector2(offScreen.x, offScreen.y);
    }

    private void RemoveParentFromMovePoint() {
        moveToPoint.transform.position = transform.position;
        moveToPoint.transform.parent = null;
    }
}