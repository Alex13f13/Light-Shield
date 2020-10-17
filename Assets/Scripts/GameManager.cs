using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameOverCheck;
   
    public GameObject GameOverUI;
    public GameObject WinUI;

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
            Debug.Log("Game Over");
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
        GameOverUI.GetComponent<GameOver>().StopTime();
    }

    public void WinLevel()
	{
        GameOverCheck = true;
        WinUI.SetActive(true);
        PlayerPrefs.SetInt("levelReached", levelUnlocked);
    }

    #endregion
}
