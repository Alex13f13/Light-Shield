using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Timeline;

public class Node : MonoBehaviour
{
	public Material hoverColor, notMoneyColor;

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	private Renderer rend;
	private Material StartColor;

	BuildManager buildManager;

	void Start()
	{
		rend = GetComponent<Renderer>();
		StartColor = rend.material;
		buildManager = BuildManager.instance;
	}

	public Vector3 GetBuildPosition()
	{
		return transform.position + new Vector3(0f,0.5f,0f);
	}

	//void OnMouseEnter()
	//{
	//	if (EventSystem.current.IsPointerOverGameObject())
	//		return;

	//	if (!buildManager.CanBuild)
	//		return;

	//	if (buildManager.HasMoney)
	//	{
	//		rend.material.color = hoverColor;
	//	}
	//	else
	//	{
	//		rend.material.color = notMoneyColor;
	//	}
	//}

	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;		

		if (turret != null)
		{
			buildManager.SelectedNode(this);
			return;
		}

		if (!buildManager.CanBuild)
			return;

		BuildTower(buildManager.GetTurretSelected());
	}

	void BuildTower(TurretBlueprint blueprint)
	{
		if (PlayerStats.Money < blueprint.cost)
		{
			Debug.Log("No hay dinero suficiente amiguo");
			return;
		}

		PlayerStats.Money -= blueprint.cost;

		GameObject Turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
		turret = Turret;

		turretBlueprint = blueprint;

		GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 4f);
	}

	public void UpgradeTower()
	{
		if (PlayerStats.Money < turretBlueprint.upgradeCost)
		{
			Debug.Log("No hay dinero para mejorar sorry");
			return;
		}

		PlayerStats.Money -= turretBlueprint.upgradeCost;

		//Eliminamos la torreta anterior
		Destroy(turret);

		//Contruimos la torreta nueva mejorada
		GameObject Turret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
		turret = Turret;

		GameObject effect = Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 4f);

		isUpgraded = true;
	}

	public void SellTurret()
	{
		PlayerStats.Money += turretBlueprint.GetSellMoney();

		GameObject effect = Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 4f);

		Destroy(turret);

		turretBlueprint = null;
	}

	void OnMouseOver()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney)
		{
			rend.material = hoverColor;
		}
		else
		{
			rend.material = notMoneyColor;
		}
	}


	void OnMouseExit()
	{
		rend.material = StartColor;
	}
}
