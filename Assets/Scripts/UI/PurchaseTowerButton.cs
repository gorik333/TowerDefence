using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseTowerButton : MonoBehaviour
{
    [SerializeField] private GameObject _towerMainPrefab;
    [SerializeField] private GameObject _towerGhostPrefab;

    [SerializeField] private Material _towerGhostAllowMaterial;
    [SerializeField] private Material _towerGhostDenyMaterial;

    [SerializeField] private LayerMask _buildTerritoryMask;

    [SerializeField] private Camera _camera;

    private MeshRenderer _towerGhostPrefabMaterial;

    private GameObject _spawnedTowerObject;

    private RaycastHit hit;

    private bool _isCanBuildTower;
    private bool _isBuilding;


    private void SpawnTowerPrefab()
    {
        _spawnedTowerObject = Instantiate(_towerGhostPrefab, transform.position, Quaternion.identity);

        _towerGhostPrefabMaterial = _spawnedTowerObject.GetComponent<MeshRenderer>();
    }


    public void OnBeginDrag()
    {
        SpawnTowerPrefab();
        LevelManager.Instance.CurrentBuildState = BuildState.StartBuild;
    }


    public void OnDrag()
    {
        if (!_isBuilding)
        {
            LevelManager.Instance.CurrentBuildState = BuildState.Building;
            _isBuilding = true;
        }

        CalculateMovePoint();
        FollowMouse();
    }


    public void OnEndDrag()
    {
        _isBuilding = false;

        Destroy(_spawnedTowerObject);

        if (_isCanBuildTower)
        {
            Tower tower = Instantiate(_towerMainPrefab, hit.point, Quaternion.identity).GetComponent<Tower>();
            tower.BuildTower();
            StartCoroutine(EndBuildDelay(tower.CurrentTowerLevel.BuildTime));
        }
        else
        {
            StartCoroutine(EndBuildDelay());
        }
    }


    private IEnumerator EndBuildDelay(float duration = 0.05f)
    {
        yield return new WaitForSeconds(duration);

        LevelManager.Instance.CurrentBuildState = BuildState.EndBuild;
    }


    private Vector3 CalculateMovePoint()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = _camera.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray, out hit, 100, _buildTerritoryMask))
            {
                IsAllowPlacing(hit.transform.gameObject);

                return hit.point;
            }
        }

        return Vector3.zero;
    }


    private void IsAllowPlacing(GameObject hitObject)
    {
        _isCanBuildTower = hitObject.CompareTag(GeneralConstanst.ALLOW_BUILD_TAG);

        //hitObjec

        if (_isCanBuildTower)
            _towerGhostPrefabMaterial.material = _towerGhostAllowMaterial;
        else
            _towerGhostPrefabMaterial.material = _towerGhostDenyMaterial;
    }


    private void FollowMouse()
    {
        if (_spawnedTowerObject != null)
        {
            _spawnedTowerObject.transform.position = CalculateMovePoint();
        }
    }
}
