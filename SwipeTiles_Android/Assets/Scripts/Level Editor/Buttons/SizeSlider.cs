using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeSlider : MonoBehaviour
{
    private Buttons buttons;

    private void Start() {
        buttons = Buttons.Instance;
    }
    public void OnValueChange() {
        if (buttons.slider.value % 2 != 0) buttons.slider.value += 1;
        buttons.cameraSize.SetCameraSize((int)buttons.slider.value);
        buttons.tilesGrid.OnGenerateGrid();
    }
}
