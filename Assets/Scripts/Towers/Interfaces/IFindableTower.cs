using UnityEngine;

public interface IFindableTower
{
    void AddEnteredEnemy(GameObject enemy);

    void RemoveQuitedEnemy(GameObject enemy);
}
