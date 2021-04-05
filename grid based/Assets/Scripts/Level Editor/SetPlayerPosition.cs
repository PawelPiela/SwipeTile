using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPosition : MonoBehaviour
{
    public static bool SettingPlayerPosition = false;
    public static Transform SelectedPlayerPos = null;
    [SerializeField] private EditorTilesManager editorTilesManager;

    public void OnSetPosition() {
        if (editorTilesManager.SelectedTiles.Count != 0) {
            SettingPlayerPosition = true;
            SelectedPlayerPos = null;
        }
    }
    
}
