using UnityEngine;
using UnityEngine.AI;


public class EnemyNavMove : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _meshAgent;

    private Mesh _nextMesh;
    private Node _nextNode;
    private Transform _nextCenter;


    private void SetDestinationPosition()
    {
        //Debug.Log(_nextNode.gameObject.name + "    " + (_nextNode.transform.position - _nextMesh.GetRandomPointOnSurface()));

        _meshAgent.SetDestination(_nextNode.transform.position - _nextMesh.GetRandomPointOnSurface());
    }


    private void FinishActions()
    {
        Debug.Log("Finish actions");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Node>() != null)
        {
            Node otherNode = other.GetComponent<Node>();
            if (otherNode.GetNextNode != null)
            {
                _nextNode = otherNode.GetNextNode;
                _nextMesh = _nextNode.GetMesh;
                _nextCenter = otherNode.Center;

                SetDestinationPosition();
            }
            else
            {
                FinishActions();
            }
        }

    }
}
