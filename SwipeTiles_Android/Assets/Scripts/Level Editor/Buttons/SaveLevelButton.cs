using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLevelButton : MonoBehaviour
{
    private Buttons buttons;

    private void Start() {
        buttons = Buttons.Instance;
        
    }
    public  void ClickButton() {
        buttons.SaveLevel.OnButtonClick();
        //buttons.SaveLevelButton.c
    }
    
    
}
