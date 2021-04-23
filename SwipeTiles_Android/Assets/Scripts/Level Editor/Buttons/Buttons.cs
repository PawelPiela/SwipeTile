using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-10)]
public class Buttons : Singleton<Buttons>
{
    public TilesGrid tilesGrid;
    public Slider slider; 
    public CameraSize cameraSize;
    public SaveLevel SaveLevel;
    public SetPlayerPosition SetPlayerPosition;
    public Button SaveLevelButton;

}
