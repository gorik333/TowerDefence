using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerInfoDisplay : MonoBehaviour
{
	[Header("Check all panels")]
    [SerializeField] private TextMeshProUGUI[] _towerName;
    [SerializeField] private TextMeshProUGUI[] _description;

	[SerializeField] private TextMeshProUGUI[] _upgradeCost;
	[SerializeField] private TextMeshProUGUI[] _sellPrice;


    public void Show(Tower tower)
    {
        int levelOfTower = tower.CurrentLevel;
        Show(tower, levelOfTower);
    }

	public void Show(Tower tower, int levelOfTower)
	{
		if (levelOfTower >= tower.LevelsCount)
		{
			return;
		}

		TowerLevel towerLevel = tower.TowerLevels[levelOfTower];
		DisplayText(_towerName, tower.TowerName);
		DisplayText(_description, towerLevel.Description);
		//DisplayText(dps, towerLevel.GetTowerDps().ToString("f2"));
		//DisplayText(health, string.Format("{0}/{1}", tower.configuration.currentHealth, towerLevel.maxHealth));
		//DisplayText(level, (levelOfTower + 1).ToString());
		//DisplayText(dimensions, string.Format("{0}, {1}", tower.dimensions.x, tower.dimensions.y));
		if (levelOfTower + 1 < tower.TowerLevels.Length)
		{
			DisplayText(_upgradeCost, tower.TowerLevels[levelOfTower + 1].Cost.ToString());
		}

		int sellValue = tower.GetSellLevel(levelOfTower);
		DisplayText(_sellPrice, sellValue.ToString());
	}


	static void DisplayText(TextMeshProUGUI[] textBox, string text)
    {
		for (int i = 0; i < textBox.Length; i++)
		{
			if (textBox != null)
			{
				textBox[i].text = text;
			}
		}
    }
}
