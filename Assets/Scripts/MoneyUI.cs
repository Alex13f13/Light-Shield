using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneytext;


    void Start()
    {
        
    }

    void Update()
    {
        moneytext.text = PlayerStats.Money.ToString() + "€"; 
    }

    #region Funciones



    #endregion
}
