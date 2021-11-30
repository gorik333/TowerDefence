using UnityEngine;

[System.Serializable]
public struct Wave
{
    [SerializeField] private int _waveNumber;

    [Header("Shooter")]
    [SerializeField] private int _shooterCount;
    [SerializeField] private float _shooterSpawnRate;
    [SerializeField] private float _shooterAfterStartSpawnDelay;


}


public class Spawner : MonoBehaviour
{
    [SerializeField] private Wave[] _wave;

    [SerializeField] private GameObject _shooterPrefab;
    [SerializeField] private GameObject _mediumTankPrefab;

    [SerializeField] private int _currentWave;

    private float _shooterSpawnDelay;
    private float _shooterCurrentSpawnDelay;


    void Start()
    {
        SetDefaultValues();
    }


    private void SetDefaultValues()
    {
        _shooterSpawnDelay = TroopConstants.SHOOTER_SPAWN_DELAY;
    }


    void Update()
    {
        SpawnShooterTimer();
    }


    public void IncreaseCurrentWave()
    {
        if (_currentWave + 1 != _wave.Length)
        {
            _currentWave++;
        }
        else
        {
            // game ends
        }
    }


    private void SpawnShooterTimer()
    {
        _shooterCurrentSpawnDelay -= Time.fixedDeltaTime;

        if (_shooterCurrentSpawnDelay <= 0)
        {
            SpawnShooter();
            _shooterCurrentSpawnDelay = _shooterSpawnDelay;
        }
    }


    private void SpawnShooter()
    {
        Instantiate(_shooterPrefab, transform.position, Quaternion.identity);
    }


    //private void SpawnMediumTank()
    //{
    //    Instantiate(_mediumTankPrefab, transform.position, Quaternion.identity);
    //}
}
