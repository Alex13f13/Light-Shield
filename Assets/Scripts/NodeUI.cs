using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject uiGO;
    public GameObject[] Selecteds;
    public Button upgradeButton;

    public Text sellCost;

    public Text upgradeCost;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #region Funciones

    public void SetTarget(Node Target)
	{
        target = Target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            upgradeCost.text = target.turretBlueprint.upgradeCost + "€";
            upgradeButton.interactable = true;
            sellCost.text = target.turretBlueprint.GetSellMoney() + "€";
        }
		else
		{
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
            sellCost.text = target.turretBlueprint.GetSellMoneyUpgraded() + "€";
        }

        uiGO.SetActive(true);

		for (int i = 0; i < Selecteds.Length; i++)
		{
            Selecteds[i].SetActive(false);
        }        
	}

    public void Hide()
	{
        uiGO.SetActive(false);
	}

    public void Upgrade()
	{
        target.UpgradeTower();
        BuildManager.instance.DeselectNode();
	}

    public void Sell()
	{
        target.SellTurret();
        BuildManager.instance.DeselectNode();
	}

    #endregion
}
