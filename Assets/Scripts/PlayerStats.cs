using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int StartMoney = 300;

    public static int Lives;
    public int StartLives = 20;

    public static int Rounds;

    void Start()
    {
        Money = StartMoney;
        Lives = StartLives;

        Rounds = 0;
    }
}
