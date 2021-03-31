using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    
    private MouseClick controls;
    private Camera mainCamera;
    [SerializeField] private Transform tile;

    private void Awake() {
        controls = new MouseClick();
        mainCamera = Camera.main;
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }

    void Start(){
        controls.Mouse.Click.performed += _ => ClickOnTile();
    }

    private void ClickOnTile(){
        Vector2 mousePosition = controls.Mouse.MousePosition.ReadValue<Vector2>();
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if(hit.transform != null){
            Debug.Log("click");
        }

    }
}
