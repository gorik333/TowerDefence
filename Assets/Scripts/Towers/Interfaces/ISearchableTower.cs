using UnityEngine;

public interface ISearchableTower
{

    void AddEnteredEnemy(GameObject enemy);

    void RemoveQuitedEnemy(GameObject enemy);
}
