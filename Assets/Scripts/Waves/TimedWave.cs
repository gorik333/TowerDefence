using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedWave : MonoBehaviour
{
    [SerializeField]
    private List<SpawnInstruction> _spawnInstructions = new List<SpawnInstruction>();

    [SerializeField]
    private float _delayBeforeNextWave;


    public int TotalInstructions
    {
        get { return _spawnInstructions.Count; }
    }


    public float GetDelayToSpawn(int index)
    {
        return _spawnInstructions[index].delayToSpawn;
    }


    public float GetDelayBeforeNextWave
    {
        get { return _delayBeforeNextWave; }
    }


    public EnemyConfiguration GetEnemyConfiguration(int index)
    {
        return _spawnInstructions[index].enemyConfiguration;
    }
}
