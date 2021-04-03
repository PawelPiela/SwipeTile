using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeSlider : Buttons
{
    [SerializeField] private Slider slider;
    [SerializeField] private CameraSize cameraSize;
    [SerializeField] private TilesGrid tilesGrid;
    public void OnValueChange() {
        if (slider.value % 2 != 0) slider.value += 1;
        cameraSize.SetCameraSize((int)slider.value);
        tilesGrid.OnGenerateGrid();
    }
}
