using UnityEngine;

[CreateAssetMenu(fileName = "TowerData.asset", menuName = "TowerDefense/Tower Configuration")]
public class TowerLevelData : ScriptableObject
{
    public string TowerName;

    public string Description;

    public string UpgradeDescription;

    public float BuildTime;

    public float FireRate;

    public float Damage;

    public float AttackRange;

    public bool IsSplashAttack;

    public int Cost;

    public int Sell;

    //public Sprite TowerIcon;
}
