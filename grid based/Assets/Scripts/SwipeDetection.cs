using UnityEngine;

public class SwipeDetection : MonoBehaviour {

    [SerializeField] private InputManager inputManager;
    [SerializeField] private float minSwipeDistance = 0.2f;
    [SerializeField] private float maxSwipeTime = 1f;
    [SerializeField, Range(0, 1)] private float directionTreshhold = 0.7f;
    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;
    private static Vector2 swipedDirection;
    [SerializeField] private Vector2 bugPos;
    public static Vector2 SwipedDirection {
        get { return swipedDirection; }
        set { swipedDirection = value; }
    }

    private void OnEnable() {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable() {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }
    
    private void SwipeStart(Vector2 position, float time) {
        startPosition = position;
        startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time) {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe() {
        if (Vector3.Distance(startPosition, endPosition) >= minSwipeDistance &&
        (endTime - startTime) <= maxSwipeTime) {
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            if (startPosition.y != bugPos.y) {
                SwipeDirection(direction2D);
            }
        }
    }
    private void SwipeDirection(Vector2 direction) {
        if (Vector2.Dot(Vector2.down, direction) > directionTreshhold) {
            swipedDirection = Vector2.down;
        }
        else if (Vector2.Dot(Vector2.up, direction) > directionTreshhold) {
            swipedDirection = Vector2.up;
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionTreshhold) {
            swipedDirection = Vector2.left;
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionTreshhold) {
            swipedDirection = Vector2.right;
        }
    }
}
