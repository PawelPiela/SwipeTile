using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerTile : MonoBehaviour {
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform movePoint;
    [SerializeField] private TilesManager tilesManager;
    private bool isMoving = false;
    private Vector3 direction = Vector3.zero;
    private Vector3 targetPos;
    public int moveCount = 0;

    private void Start() {
        movePoint.transform.position = transform.position;
        movePoint.transform.parent = null;
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
        bool isChecked = false;
        while (!isChecked) {
            Vector3 prevPos = movePoint.transform.position;
            movePoint.transform.position = movePoint.transform.position + new Vector3(direction.x, direction.y, direction.z);
            if (tilesManager.tiles.Find(tilePos => tilePos.position == movePoint.transform.position)) {
                targetPos = movePoint.transform.position;
            } else {
                movePoint.transform.position = new Vector3(prevPos.x, prevPos.y, prevPos.z);
                isChecked = true;
            }
        }
        return targetPos;
    }

    private void MovementInput() {
        if (!isMoving) {
            direction = SwipeDetection.SwipedDirection;
        }
    }
}
