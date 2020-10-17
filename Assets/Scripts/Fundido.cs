using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fundido : MonoBehaviour
{
    public Image imagen;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    #region Funciones

    IEnumerator FadeIn()
	{
        float t = 1f;

		while (t>0f)
		{
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            imagen.color = new Color(0f,0f,0f,a);
            yield return 0;
		}
	}

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            imagen.color = new Color(0f, 0f, 0f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }

    #endregion
}
