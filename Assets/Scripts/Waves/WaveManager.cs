using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] _enemySpawnPosition;

    [SerializeField]
    private int _currentWave;

    [SerializeField]
    private List<TimedWave> _waves = new List<TimedWave>();

    private TimedWave _currentTimedWave;
    private int _currentTimedWaveInstructionIndex;

    private EnemyConfiguration _currentEnemy;

    private float _currentTimeToSpawn;

    private bool _isWaveEnd;


    void Start()
    {
        StartWaves();
    }


    void FixedUpdate()
    {
        if (!_isWaveEnd)
            TimerToSpawnEnemies();
    }


    private void TimerToSpawnEnemies()
    {
        _currentTimeToSpawn -= Time.fixedDeltaTime;

        if (_currentTimeToSpawn <= 0)
        {
            SpawnInstruction();
            SpawnEnemy();
            IncreaseCurrentInstructionIndex();
        }
    }


    private void SpawnInstruction()
    {
        _currentEnemy = _currentTimedWave.GetEnemyConfiguration(_currentTimedWaveInstructionIndex);
        _currentTimeToSpawn = _currentTimedWave.GetDelayToSpawn(_currentTimedWaveInstructionIndex);
    }

    private void SpawnEnemy()
    {
        int randomSpawnIndex = Random.Range(0, _enemySpawnPosition.Length);

        Instantiate(_currentEnemy.EnemyPrefab, _enemySpawnPosition[randomSpawnIndex].position, Quaternion.identity);
    }


    private void IncreaseCurrentInstructionIndex()
    {
        if (_currentTimedWaveInstructionIndex + 1 < _currentTimedWave.TotalInstructions)
        {
            _currentTimedWaveInstructionIndex++;
        }
        else
        {
            StartCoroutine(StartNextWave());
        }
    }


    private IEnumerator StartNextWave()
    {
        float duration = _currentTimedWave.GetDelayBeforeNextWave;
        _isWaveEnd = true;

        yield return new WaitForSeconds(duration);

        IncreaseCurrentWave();
    }


    public void StartWaves()
    {
        if (_waves.Count > 0)
        {
            InitCurrentWave();
        }
        else
        {
            Debug.LogWarning("[LEVEL] No Waves on wave manager. Calling spawningCompleted");
        }
    }


    private void InitCurrentWave()
    {
        _currentTimedWave = _waves[_currentWave];
    }


    public void IncreaseCurrentWave()
    {
        if (_currentWave + 1 < _waves.Count)
        {
            _currentWave++;
            _currentTimedWave = _waves[_currentWave];
            _currentTimedWaveInstructionIndex = 0;
            _isWaveEnd = false;
        }
        else
        {
            EndOfTheGame();
        }
    }


    private void EndOfTheGame()
    {
        Debug.Log("Waves end, action to win game");
    }


    public int WaveNumber
    {
        get { return _currentWave + 1; }
    }
}
