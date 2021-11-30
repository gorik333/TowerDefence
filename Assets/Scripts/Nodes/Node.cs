using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private Node _nextNode;
    [SerializeField] private MeshFilter _meshFiler;
    [SerializeField] private Transform _center;

    private Mesh _mesh;


    void Start()
    {
        _mesh = _meshFiler.mesh;
    }


    public Transform Center
    {
        get { return _center; }
    }


    public Mesh GetMesh
    {
        get { return _mesh; }
    }


    public Node GetNextNode
    {
        get { return _nextNode; }
    }
}
