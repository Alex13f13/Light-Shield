using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
	public GameObject prefab;
	public int cost;

	public GameObject upgradedPrefab;
	public int upgradeCost;

	public int GetSellMoney()
	{
		return cost / 2;
	}
	public int GetSellMoneyUpgraded()
	{
		return (cost + upgradeCost) / 2;
	}
}
