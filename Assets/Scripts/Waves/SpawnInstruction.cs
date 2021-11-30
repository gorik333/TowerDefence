using UnityEngine;

[System.Serializable]
public class SpawnInstruction 
{
    public EnemyConfiguration enemyConfiguration;

    [Tooltip("The delay from the previous spawn until when this agent is spawned")]
    public float delayToSpawn;
}
