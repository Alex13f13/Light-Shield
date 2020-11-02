using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public GameObject waveUiPrefab;
    public WaveSpawner waveSpawner;
    public GameObject[] WaveArray;

    void Start()
    {
        PutWavesUI();
    }

    void Update()
    {
        
    }

    #region Funciones

    public void PutWavesUI()
	{
		for (int i = 0; i < waveSpawner.waves.Length; i++)
		{
            Instantiate(waveUiPrefab, transform);
        }

        
    }

    public void ResetArray()
	{        
        WaveArray = new GameObject[transform.childCount];
        for (int i = 0; i < WaveArray.Length; i++)
        {
            WaveArray[i] = transform.GetChild(i).gameObject;
        }
        Destroy(WaveArray[0]);
    }

    #endregion
}
