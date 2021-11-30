using UnityEngine;

[CreateAssetMenu(fileName = "TowerData.asset", menuName = "TowerDefense/Enemy Configuration")]
public class Enemy—haracteristicsData : ScriptableObject
{
    public string EnemyName;

    public string Description;

    public float MaxHealth;

    public EnemyArmorType EnemyArmorType;

    public bool IsFlying;

    public float MoveSpeed;

    public float AngularSpeed;
}
