using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour
{

    public Sprite[] StarsGame;
    public Image StarsImage;


	private void OnEnable()
	{
        StartCoroutine(AnimatedText());        
    }

    #region Funciones

    public Sprite SetStartSprite(int starAmount, Image image)
    {
        switch (starAmount)
        {
            case 0:
                image.sprite = StarsGame[starAmount];
                break;

            case 1:
                image.sprite = StarsGame[starAmount];
                break;

            case 2:
                image.sprite = StarsGame[starAmount];
                break;

            case 3:
                image.sprite = StarsGame[starAmount];
                break;
        }
        return image.sprite;
    }

    IEnumerator AnimatedText()
    {
        int stars = 0;
        yield return new WaitForSecondsRealtime(0.7f);
        if (PlayerStats.StarsAmount > 0)
        {
            while (stars < PlayerStats.StarsAmount)
            {
                stars++;
                SetStartSprite(stars, StarsImage);
                yield return new WaitForSecondsRealtime(0.7f);
            }
        }
    }

    #endregion
}
