using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelButton : MonoBehaviour
{
    private Buttons buttons;

    private void Start() {
        buttons = Buttons.Instance;
    }
    public void ClickButton() {
        buttons.tilesGrid.OnGenerateGrid();
    }

}
