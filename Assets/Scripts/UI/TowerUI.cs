using UnityEngine;

public class TowerUI : MonoBehaviour
{
    [SerializeField] private GameObject _towerUIPanel;
    [SerializeField] private GameObject _maxTowerLevelUIPanel;

    [SerializeField] private TowerInfoDisplay _towerInfoDisplay;

    [SerializeField] private Camera _mainCamera;

    [SerializeField] private LayerMask _towerMask;
    [SerializeField] private LayerMask _UIMask;

    private Tower _currentTower;

    RaycastHit hit;


    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (!_towerUIPanel.activeInHierarchy)
            {
                if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.GetTouch(0).position), out hit, 1000, _towerMask))
                {
                    if (hit.transform.GetComponentInParent<Tower>() != null && LevelManager.Instance.CurrentBuildState == BuildState.EndBuild)
                    {
                        _currentTower = hit.transform.GetComponentInParent<Tower>();
                        if (_currentTower.CurrentLevel + 1 >= _currentTower.TowerLevels.Length)
                        {
                            OpenMaxTowerLevelPanelOn();
                        }
                        else
                        {
                            OpenTowerPanel();
                        }
                    }
                }
            }
        }
    }


    public void UpgradeTowerOnClick()
    {
        if (_currentTower != null)
        {
            _currentTower.Upgrade();
            if (_currentTower.CurrentLevel + 1 >= _currentTower.TowerLevels.Length)
            {
                OpenMaxTowerLevelPanelOn();
            }
            else
            {
                UpdateInfoDisplay();
            }
        }
    }


    public void SellTowerOnClick()
    {
        if (_currentTower != null)
        {
            _currentTower.Sell();
            CloseTowerPanelOnClick();
            CloseMaxedTowerPanelOnClick();
        }
    }


    private void OpenTowerPanel()
    {
        _towerUIPanel.SetActive(true);

        UpdateInfoDisplay();
    }


    private void OpenMaxTowerLevelPanelOn()
    {
        CloseTowerPanelOnClick();
        _towerInfoDisplay.Show(_currentTower);
        _maxTowerLevelUIPanel.SetActive(true);
    }


    private void UpdateInfoDisplay()
    {
        _towerInfoDisplay.Show(_currentTower);
    }


    public void CloseTowerPanelOnClick()
    {
        _towerUIPanel.SetActive(false);
    }


    public void CloseMaxedTowerPanelOnClick()
    {
        _maxTowerLevelUIPanel.SetActive(false);
    }
}
