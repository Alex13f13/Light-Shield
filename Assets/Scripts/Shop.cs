using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint StandardTurret, missileLauncher, LaserBeamer;

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
        Debug.Log("Standard Turret Selected");
        buildManager.SetTurretSelected(StandardTurret);
	}

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManager.SetTurretSelected(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        buildManager.SetTurretSelected(LaserBeamer);
    }

    #endregion
}
