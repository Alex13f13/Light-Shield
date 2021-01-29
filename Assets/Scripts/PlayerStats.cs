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
    public static int StarsScore;
    //public int score;

    public static int StarsAmount;
    //public int starsAmount;

    void Start()
    {
        Money = StartMoney;
        Lives = StartLives;

        Rounds = 0;
        Score = 0;
        StarsAmount = 0;
        StarsScore = 0;
    }
	//void Update()
	//{
	//	score = StarsScore;
	//}
}
