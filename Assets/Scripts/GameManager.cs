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

    public int Stars1;
    public int Stars2;
    public int Stars3;

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
        //PlayerStats.Score += PlayerStats.Money;
        if(PlayerStats.StarsScore >= Stars3)
		{
            PlayerStats.StarsAmount = 3;
        }
        else if (PlayerStats.StarsScore >= Stars2)
        {
            PlayerStats.StarsAmount = 2;
        }
        else if (PlayerStats.StarsScore >= Stars1)
        {
            PlayerStats.StarsAmount = 1;
        }
        WinUI.GetComponent<Win>().StopTime();
		if (levelUnlocked < 11 && PlayerPrefs.GetInt("levelReached") < levelUnlocked)
		{
            PlayerPrefs.SetInt("levelReached", levelUnlocked);
        }
		if (PlayerStats.StarsAmount < GetStar(levelUnlocked - 1))
		{
            return;
		}
        SetStar(levelUnlocked - 1, PlayerStats.StarsAmount);
    }

    private void SetStar(int Level, int starAmount)
    {
        PlayerPrefs.SetInt(GetKey(Level), starAmount);
    }

    private string GetKey(int Level)
    {
        return "Level_" + Level + "_Star";
    }

    private int GetStar(int Level)
    {
        return PlayerPrefs.GetInt(GetKey(Level));
    }

    #endregion
}
