using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour
{   
    public Fundido fundido;

    public string MenuSceneName = "MainMenu";

    public Animator anim;

    public GameObject ui;

	void Update()
	{
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            anim.enabled = false;
        }
    }

	#region Funciones
	public void StopTime()
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
        StopTime();
        fundido.FadeTo(SceneManager.GetActiveScene().name);
	}

    public void Menu()
    {
        StopTime();
        fundido.FadeTo(MenuSceneName);
    }

    #endregion
}
