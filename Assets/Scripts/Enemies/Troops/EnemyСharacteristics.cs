using UnityEngine;

[DisallowMultipleComponent]
public class EnemyСharacteristics : MonoBehaviour
{
    [SerializeField] private EnemyСharacteristicsData _data;


    public string EnemyName
    {
        get { return _data.EnemyName; }
    }

    public string Description
    {
        get { return _data.Description; }
    }


    public EnemyArmorType EnemyArmorType
    {
        get { return _data.EnemyArmorType; }
    }


    public float MaxHealth
    {
        get { return _data.MaxHealth; }
    }


    public bool IsFlying
    {
        get { return _data.IsFlying; }
    }


    public float MoveSpeed
    {
        get { return _data.MoveSpeed; }
    }


    public float AngularSpeed
    {
        get { return _data.AngularSpeed; }
    }
}
