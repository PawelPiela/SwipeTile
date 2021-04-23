using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-150)]
public class Level : SingletonPersistant<Level>
{
    private static int levelIndex = 1;
    public static int LevelIndex {
        get { return levelIndex; }
        set { levelIndex = value; }
    }
    private static Color color;
    private static Vector2Int playerPos;
    private static List<Vector2Int> preparedTilesPositions = new List<Vector2Int>();
    private static int cameraSize;
    
    
    public override void Awake() { base.Awake(); }

    public static void SetCameraSize(int size) { cameraSize = size; }

    public static void SetPlayerPosition(Vector2Int playerPosition) { playerPos = playerPosition; }

    public static void SetTilesPositions(List<Vector2Int> positions) { preparedTilesPositions = positions; }

    public static void SetColor(Color selectedColor) { color = selectedColor; }
    
    public static int GetCameraSize() { return cameraSize; }

    public static Vector2Int GetPlayerPosition() { return playerPos; }

    public static List<Vector2Int> GetTilesPositions() { return preparedTilesPositions; }
    public static Color GetColor() { return color; }
    
    
}
