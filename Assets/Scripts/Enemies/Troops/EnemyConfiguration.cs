using UnityEngine;

[CreateAssetMenu(fileName = "AgentConfiguration.asset", menuName = "TowerDefense/Enemy Configuration")]
public class EnemyConfiguration : ScriptableObject
{
    public string EnemyName;

    [Multiline]
    public string EnemyDescription;

    public Enemy—haracteristics EnemyPrefab;
}
