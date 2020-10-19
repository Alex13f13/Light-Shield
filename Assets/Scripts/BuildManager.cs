using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

	void Awake()
	{
		if (instance != null)
		{
            Debug.Log("Hay más de un BuildManager en la escena crack");
            return;
		}
        instance = this;
	}

    public GameObject buildEffect;
    public GameObject sellEffect;

	private TurretBlueprint turretSelected;
	private Node selectedNode;

	public NodeUI nodeUI;

    void Update()
    {
        
    }

	#region Funciones

	//Función corta de tipo bool que sirve para optener el resultado de
	//si se puede contruir o no de una forma rápida.El "get" sirve
	//para que coja ese resultado que le devuelve el "return".
	public bool CanBuild { get { return turretSelected != null; } }

	public bool HasMoney { get { return PlayerStats.Money >= turretSelected.cost; } } //Ejem2: Si tiene dinero = true

	public void SelectedNode (Node node)
	{
		if (selectedNode == node)
		{
			DeselectNode();
			return;
		}

		selectedNode = node;
		turretSelected = null;

		nodeUI.SetTarget(node);
	}

	public void DeselectNode()
	{
		selectedNode = null;
		nodeUI.Hide();
	}


	public void SetTurretSelected(TurretBlueprint turret)
	{
        turretSelected = turret;
		DeselectNode();
	}

	public TurretBlueprint GetTurretSelected()
	{
		return turretSelected;
	}

    #endregion
}
