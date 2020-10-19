using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvied : MonoBehaviour
{
    public Text roundsText;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #region Funciones

    void OnEnable()
    {
        StartCoroutine(AnimatedText());
    }

    IEnumerator AnimatedText()
	{
        roundsText.text = "0";
        int round = 0;
        yield return new WaitForSeconds(0.7f);
		while (round < PlayerStats.Rounds)
		{
            round++;
            roundsText.text = round.ToString();
            yield return new WaitForSeconds(0.05f);
		}
	}

    #endregion
}
