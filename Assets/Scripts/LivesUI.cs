using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Text livesText;


    void Start()
    {
        
    }

    void Update()
    {
		if (PlayerStats.Lives < 2)
		{
            livesText.text = PlayerStats.Lives + " LIVE";
            return;
        }

        livesText.text = PlayerStats.Lives + " LIVES";
    }

    #region Funciones



    #endregion
}
