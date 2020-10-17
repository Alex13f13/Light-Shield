using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string LeveltoLoad = "GamePlay";

    public Fundido fundido;

    #region Funciones

    public void Play()
	{
        fundido.FadeTo(LeveltoLoad);
	}

    public void Options()
    {
        fundido.FadeTo("OptionsMenu");
    }

    public void Exit()
	{
        Application.Quit();
	}

    #endregion
}
