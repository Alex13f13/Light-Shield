using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject uiGO;
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
        }
		else
		{
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }

        sellCost.text = target.turretBlueprint.GetSellMoney() + "€";

        uiGO.SetActive(true);
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
