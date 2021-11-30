using UnityEngine;

public class TowerRadiusTrigger : MonoBehaviour, IRangeable
{
    [SerializeField] private TowerAttackAffector _attackAffector;
    [SerializeField] private SphereCollider _sphereCollider;


    public float GetAttackRangeDistance()
    {
        return _sphereCollider.radius;
    }


    public void SetAttackRangeDistance(float newDistance)
    {
        _sphereCollider.radius = newDistance / 2f;
    }


    private void OnTriggerEnter(Collider other)
    {
        _attackAffector.AddEnteredEnemy(other.gameObject);
    }


    private void OnTriggerExit(Collider other)
    {
        _attackAffector.RemoveQuitedEnemy(other.gameObject);
    }
}
