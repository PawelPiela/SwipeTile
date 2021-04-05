using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private int defaultSize = 6;
    private void Awake() {
        mainCamera = Camera.main;
        mainCamera.orthographicSize = defaultSize;
   }
   
    public void SetCameraSize(int size) {
        mainCamera.orthographicSize = size;
    }

    public int GetCameraSize() {
        return (int)mainCamera.orthographicSize;
    }
    
}
