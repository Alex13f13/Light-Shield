using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameOverCheck;
   
    public GameObject GameOverUI;
    public GameObject WinUI;

    public GameObject audiosource;

    public CameraController cameraController;

    public int levelUnlocked;

    void Start()
    {
        GameOverCheck = false;
    }

    void Update()
    {
        if (GameOverCheck)
		{
            return;
		}

		if (PlayerStats.Lives <= 0)
		{
            EndGame();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            cameraController.enabled = !cameraController.enabled;
        }
    }

    #region Funciones

    void EndGame()
	{
        GameOverCheck = true;
        audiosource.SetActive(false);
        GameOverUI.GetComponent<GameOver>().StopTime();
    }

    public void WinLevel()
	{
        GameOverCheck = true;
        audiosource.SetActive(false);
        PlayerStats.Score += PlayerStats.Money;
        WinUI.GetComponent<Win>().StopTime();
        PlayerPrefs.SetInt("levelReached", levelUnlocked);
    }

    #endregion
}
