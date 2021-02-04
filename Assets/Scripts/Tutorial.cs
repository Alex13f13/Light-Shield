using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Tutorial : MonoBehaviour
{
    public GameObject ui;
    public GameObject GameManager;

	private void Start()
	{
        StartCoroutine(Wait());
    }

    #region Funciones

    public void Next()
	{
        Time.timeScale = 1f;
        ui.SetActive(false);
        GameManager.GetComponent<PauseMenu>().enabled = true;
    }

    IEnumerator Wait()
	{
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0f;
    }

    #endregion
}
