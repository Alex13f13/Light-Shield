using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bontones : MonoBehaviour
{
    public AudioClip[] BotonAUS;
    public AudioSource audiosource;
    public int randomINT;
    public Button button;

    void Start()
    {       
        button.onClick.AddListener(PlaySound);
    }

	public void PlaySound()
    {
        randomINT = Random.Range(0, BotonAUS.Length);
        audiosource.PlayOneShot(BotonAUS[randomINT]);
    }

    #region Funciones



    #endregion
}
