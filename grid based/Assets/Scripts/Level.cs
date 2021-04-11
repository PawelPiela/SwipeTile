using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-200)]
public class Level : Singleton<Level>
{
    private static int levelIndex = 1;
    public static int LevelIndex {
        get {
            return levelIndex;
        }
        set {
            if (value <= 0) levelIndex = value;
        }
    }
    public override void Awake() {
        base.Awake();
    }
}
