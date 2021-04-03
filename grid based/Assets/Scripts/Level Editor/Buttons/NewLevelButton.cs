using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelButton : Buttons
{
    [SerializeField] private TilesGrid tilesGrid;

    public void ClickButton() {
        tilesGrid.OnGenerateGrid();
    }

}
