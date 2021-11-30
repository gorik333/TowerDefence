using UnityEngine;

public interface IDamageableTroop<T>
{
    void TakeDamage(T amount, Vector3 hitPoint, TowerType type);

    bool IsDied();
}
