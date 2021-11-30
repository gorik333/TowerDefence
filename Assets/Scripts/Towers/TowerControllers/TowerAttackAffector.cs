using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackAffector : MonoBehaviour
{
    [SerializeField] private TowerRadiusTrigger _towerRadiusTrigger;
    [SerializeField] private TowerLevel _towerLevel;

    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform[] _projectilePoints;
    [SerializeField] private Transform _epicenter;

    [SerializeField] private TowerType _towerType;

    private bool _isSplashAttack;

    private float _fireRate;
    private float _fireRateMultiplier;
    private float _damage;
    private float _attackRange;

    private float _currentReloadTime;

    private List<GameObject> _enemiesList;
    private GameObject _currentEnemy;


    void Start()
    {
        _enemiesList = new List<GameObject>();
        SetDefaultValues();
        SetAttackRange();
    }


    void Update()
    {
        if (_currentEnemy == null)
        {
            FollowClosestEnemyToExit();
        }
        Reload();
    }

    private void SetAttackRange()
    {
        _towerRadiusTrigger.SetAttackRangeDistance(_attackRange);
    }


    private void SetDefaultValues()
    {
        _fireRate = TowerConstants.BASE_FIRE_RATE;

        _fireRateMultiplier = _towerLevel.FireRate;
        _attackRange = _towerLevel.AttackRange;
        _damage = _towerLevel.Damage;
        _isSplashAttack = _towerLevel.IsSplashAttack;

        _fireRate /= _fireRateMultiplier;
    }


    private void Reload()
    {
        _currentReloadTime -= Time.deltaTime;

        if (_currentReloadTime <= 0)
        {
            _currentReloadTime = _fireRate;

            AttackClosestEnemyToExit();
        }
    }


    private void FollowClosestEnemyToExit()
    {
        float highestTravelledDistance = 0;

        for (int i = 0; i < _enemiesList.Count; i++)
        {
            if (_enemiesList[i] == null)
            {
                RemoveKilledEnemy(_enemiesList[i]);
                continue;
            }

            IMoveable moveable = _enemiesList[i].GetComponent<IMoveable>();

            if (moveable.GetTravelledDistance() > highestTravelledDistance)
            {
                _currentEnemy = _enemiesList[i];
                highestTravelledDistance = moveable.GetTravelledDistance();
            }
        }
    }


    private void AttackClosestEnemyToExit()
    {
        if (_currentEnemy != null)
        {
            IDamageableTroop<float> damageableTroop = _currentEnemy.GetComponent<IDamageableTroop<float>>();
            damageableTroop.TakeDamage(_damage, Vector3.zero, _towerType);
            SpawnProjectile();

            if (damageableTroop.IsDied())
            {
                RemoveKilledEnemy(_currentEnemy);
            }
        }
    }


    private void SpawnProjectile()
    {
        for (int i = 0; i < _projectilePoints.Length; i++)
        {
            Instantiate(_projectile, _projectilePoints[i]);
        }
    }


    private void RemoveKilledEnemy(GameObject enemy)
    {
        if (_enemiesList.Contains(enemy))
        {
            _enemiesList.Remove(enemy);
        }
    }


    public void AddEnteredEnemy(GameObject enemy)
    {
        if (enemy != null && !_enemiesList.Contains(enemy))
        {
            _enemiesList.Add(enemy);
        }
    }


    public void RemoveQuitedEnemy(GameObject enemy)
    {
        if (_enemiesList.Contains(enemy))
        {
            _enemiesList.Remove(enemy);
        }
    }


    public GameObject GetCurrentEnemy()
    {
        return _currentEnemy;
    }
}

