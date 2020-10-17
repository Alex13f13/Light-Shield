using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;

    public Fundido fundido;
    public string MenuSceneName = "MainMenu";

    void Start()
    {
        
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
            Continue();
		}
    }

    #region Funciones

    public void Continue()
	{
        ui.SetActive(!ui.activeSelf);

		if (ui.activeSelf)
		{
            Time.timeScale = 0f;
		}
		else
		{
            Time.timeScale = 1f;
		}
	}

    public void Retry()
	{
        Continue();
        fundido.FadeTo(SceneManager.GetActiveScene().name);
	}

    public void Menu()
    {
        Continue();
        fundido.FadeTo(MenuSceneName);
    }

    #endregion
}
