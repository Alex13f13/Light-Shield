using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvied : MonoBehaviour
{
    public Text ScoreText;

    #region Funciones

    void OnEnable()
    {
        StartCoroutine(AnimatedText());
    }

    IEnumerator AnimatedText()
	{
        ScoreText.text = "0";
        int score = PlayerStats.Score;
        yield return new WaitForSecondsRealtime(0.7f);
        if(PlayerStats.Score >= 50)
		{
            score = score - 50;
        }        
        while (score < PlayerStats.Score)
		{
            score++;
            ScoreText.text = score.ToString();
            yield return new WaitForSecondsRealtime(0.01f);
        }
	}

    #endregion
}
