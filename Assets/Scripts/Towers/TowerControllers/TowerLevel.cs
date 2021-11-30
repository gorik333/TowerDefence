using UnityEngine;

[DisallowMultipleComponent]
public class TowerLevel : MonoBehaviour
{
    [SerializeField] private TowerLevelData _data;


    public int Cost
    {
        get { return _data.Cost; }
    }


    public int Sell
    {
        get { return _data.Sell; }
    }


    public float Damage
    {
        get { return _data.Damage; }
    }


    public float FireRate
    {
        get { return _data.FireRate; }
    }


    public float AttackRange
    {
        get { return _data.AttackRange; }
    }


    public string TowerName
    {
        get { return _data.TowerName;  }
    }

    public string Description
    {
        get { return _data.Description; }
    }


    public bool IsSplashAttack
    {
        get { return _data.IsSplashAttack; }
    }


    public string UpgradeDescription
    {
        get { return _data.UpgradeDescription; }
    }


    public float BuildTime
    {
        get { return _data.BuildTime; }
    }
}
