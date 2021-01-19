using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvied : MonoBehaviour
{
    public Text ScoreText;

    public GameObject Stars;

    public bool win;

    #region Funciones

    void OnEnable()
    {
        StartCoroutine(AnimatedText());
    }

    IEnumerator AnimatedText()
	{
        ScoreText.text = "0";
        int score = PlayerStats.StarsScore;
        yield return new WaitForSecondsRealtime(0.7f);
        if (PlayerStats.StarsScore > 0)
        {
            if (PlayerStats.StarsScore >= 50)
            {
                score = score - 50;
            }
            while (score < PlayerStats.StarsScore)
            {
                score++;
                ScoreText.text = score.ToString();
                yield return new WaitForSecondsRealtime(0.01f);
            }
        }
		if (win)
		{
            Stars.SetActive(true);
        }       
    }

    #endregion
}
