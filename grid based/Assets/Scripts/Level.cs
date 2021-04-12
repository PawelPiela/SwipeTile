using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-150)]
public class Level : SingletonPersistant<Level>
{
    private static int levelIndex;
    public static int LevelIndex {
        get {
            return levelIndex;
        }
        set {
            levelIndex = value;
        }
    }
    public void Awake() {
        base.Awake();
        levelIndex = 1;
    }
}
