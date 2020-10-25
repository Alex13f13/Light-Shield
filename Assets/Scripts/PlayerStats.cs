using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int StartMoney;

    public static int Lives;
    public int StartLives;

    public static int Rounds;
    public static int Score;
    public int score;

    void Start()
    {
        Money = StartMoney;
        Lives = StartLives;

        Rounds = 0;
        Score = 0;
    }
	void Update()
	{
        score = Score;
    }
}
