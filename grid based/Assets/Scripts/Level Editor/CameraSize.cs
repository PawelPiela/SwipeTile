using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    private Camera mainCamera;

    private int size;
    public int Size {
        get { return size; }
        set { size = Mathf.Clamp(value, minCameraSize, maxCameraSize); }
    }
   [SerializeField] private int minCameraSize;
   [SerializeField] private int maxCameraSize;
   private void Awake() {
        mainCamera = Camera.main;
    }
   
    public void SetCameraSize() {
        
    }
}
