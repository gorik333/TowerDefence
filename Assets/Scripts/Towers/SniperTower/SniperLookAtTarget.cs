using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperLookAtTarget : MonoBehaviour
{
    [SerializeField] private TowerAttackAffector _towerAttackAffector;

    private GameObject _currentEnemy;


    void Update()
    {
        _currentEnemy = _towerAttackAffector.GetCurrentEnemy();
        if (_currentEnemy != null)
        {
            LookAtEnemy();
        }
    }


    private void LookAtEnemy()
    {
        transform.LookAt(_currentEnemy.transform);
    }
}
