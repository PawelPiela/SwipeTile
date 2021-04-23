using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPositionButton : MonoBehaviour
{
    private Buttons buttons;

    private void Start() {
        buttons = Buttons.Instance;
    }
    public void ClickButton() {
        buttons.SetPlayerPosition.OnSetPosition();
        
    }
}
