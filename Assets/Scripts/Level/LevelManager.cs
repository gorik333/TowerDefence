using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : Singleton<LevelManager>
{
    public LevelState CurrentLevelState { get; set; }

    public BuildState CurrentBuildState { get; set; }
}
