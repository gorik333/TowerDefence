using UnityEngine;

public class EnemyDamageable : MonoBehaviour, IDamageableTroop<float>, IMoveable
{
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _maxHealth;

    [SerializeField] private EnemyHealthBar _enemyHealthBar;
    [SerializeField] private Enemy—haracteristics _enemy—haracteristics;

    private float _travelledDistance;

    private bool _isDied;


    void Start()
    {
        SetDefaultCharacteristics();
    }


    void FixedUpdate()
    {
        _travelledDistance += Time.fixedDeltaTime;
    }


    private void SetDefaultCharacteristics()
    {
        _maxHealth = _enemy—haracteristics.MaxHealth;
        _currentHealth = _maxHealth;
    }


    public void TakeDamage(float damage, Vector3 hitPoint, TowerType type)
    {
        //Debug.Log($"Damage received: {damage}");

        if (damage < 0)
            damage = 0;

        _currentHealth -= damage;

        CheckIfAlive();
    }


    private void CheckIfAlive()
    {
        if (_currentHealth <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        //Debug.Log("I DIED, SHOOTER");
        _isDied = true;
        Destroy(gameObject);
    }


    public float GetTravelledDistance() { return _travelledDistance; }

    public bool IsDied() { return _isDied; }
}
