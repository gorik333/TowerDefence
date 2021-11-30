using UnityEngine;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerLevel[] _towerLevel;

    [SerializeField] private int _currentLevel;

    [SerializeField] private string _towerName;

    private bool _isAtMaxLevel;

    private TowerLevel _currentTowerLevel;


    public TowerLevel[] TowerLevels
    {
        get { return _towerLevel; }
    }


    public TowerLevel CurrentTowerLevel
    {
        get { return _towerLevel[_currentLevel]; }
    }


    public string TowerName
    {
        get { return _towerName; }
    }


    public int CurrentLevel
    {
        get { return _currentLevel; }
    }


    public int LevelsCount
    {
        get { return _towerLevel.Length; }
    }


    public int GetCostForNextLevel()
    {
        if (_isAtMaxLevel)
        {
            return -1;
        }
        return _towerLevel[_currentLevel + 1].Cost;
    }


    public int GetSellLevel(int level)
    {
        if (LevelManager.Instance.CurrentLevelState == LevelState.BuildingPhase)
        {
            int cost = 0;
            for (int i = 0; i <= level; i++)
            {
                cost += _towerLevel[i].Cost;
            }

            return cost;
        }
        return _towerLevel[_currentLevel].Sell;
    }


    public int PurchaseCost
    {
        get { return _towerLevel[0].Cost; }
    }


    public bool Upgrade()
    {
        if (_isAtMaxLevel)
        {
            return false;
        }

        SetLevel(_currentLevel + 1);

        return true;
    }


    public bool DowngradeTower()
    {
        if (_currentLevel == 0)
        {
            return false;
        }
        SetLevel(_currentLevel - 1);

        return true;
    }


    public void BuildTower()
    {
        SetLevel(0);
    }


    protected void SetLevel(int level)
    {
        if (level < 0 || level >= _towerLevel.Length)
        {
            return;
        }

        _currentLevel = level;

        if (_currentTowerLevel != null)
        {
            Destroy(_currentTowerLevel.gameObject);
        }

        _currentTowerLevel = Instantiate(_towerLevel[_currentLevel], transform);
    }


    public void Sell()
    {
        Remove();
    }


    private void Remove()
    {
        //placementArea.Clear(gridPosition, dimensions);
        Destroy(gameObject);
    }
}
