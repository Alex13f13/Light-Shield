using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint StandardTurret, missileLauncher, LaserBeamer, Antiaereo;

    BuildManager buildManager;


    void Start()
    {
        buildManager = BuildManager.instance;
    }

    void Update()
    {
        
    }

    #region Funciones

    public void SelectStandardTurret()
	{
        buildManager.SetTurretSelected(StandardTurret);
	}

    public void SelectMissileLauncher()
    {
        buildManager.SetTurretSelected(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        buildManager.SetTurretSelected(LaserBeamer);
    }

    public void SelectAntiaereo()
    {
        buildManager.SetTurretSelected(Antiaereo);
    }

    #endregion
}
