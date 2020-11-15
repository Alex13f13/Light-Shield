using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonesFunciones : MonoBehaviour
{
    public Button button;

    public GameObject Numero;
    public GameObject Candado;
    public bool candado;

    public Image Stars;
    public int starsAmount;

    public LevelSelector LevelSelector;

    void Start()
    {
        candado = false;

        LevelSelector = FindObjectOfType<LevelSelector>();
    }

    void Update()
    {
        if (candado)
        {
            return;
        }

        if (button.interactable == false)
        {
            Numero.SetActive(false);
            Candado.SetActive(true);
            candado = true;
        }
        else
        {
            Stars.sprite = LevelSelector.SetStartSprite(starsAmount, Stars);
            candado = true;
        }
    }
}
