using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Fundido fundido;

    public string MenuSceneName = "MainMenu";

    public Animator anim;

    public GameObject ui;

    public string nextLevel;


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

    public void Continue()
    {
        StopTime();        
        fundido.FadeTo(nextLevel);
    }

    public void Menu()
    {
        StopTime();
        fundido.FadeTo(MenuSceneName);
    }

    #endregion
}
