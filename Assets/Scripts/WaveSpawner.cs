using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;
 
    public Transform SpawnPoint;

    public float TimeBetweenWaves = 1f;
    private float countDown = 1f;

    public Text WaveCountDownText;

    private int WaveIndex = 0;

    public GameManager gameManager;

	public void Start()
	{
        EnemiesAlive = 0;
    }

	void Update()
    {        
        if (EnemiesAlive > 0)
		{
            return;
		}

        if (WaveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countDown <= 0f)
		{
            StartCoroutine(SpawnWave());
            countDown = TimeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        WaveCountDownText.text = string.Format("{0:00.00}", countDown);
    }

    #region Funciones

    IEnumerator SpawnWave()
	{
        //PlayerStats.Rounds++;

        Wave wave = waves[WaveIndex];

        EnemiesAlive = wave.count;
        

        for (int i = 0; i < wave.count; i++)
		{
            int RandomNumber = Random.Range(0, wave.enemy.Length);
            SpawnEnemy(wave.enemy[RandomNumber]);
            yield return new WaitForSeconds(1f / wave.rateToNextEnemy);
        }
        
        WaveIndex++;		
	}

    void SpawnEnemy(GameObject enemy)
	{
        Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
	}

    #endregion
}
