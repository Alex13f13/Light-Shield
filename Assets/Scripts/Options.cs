using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class Options : MonoBehaviour
{
    public string LeveltoLoad = "MainMenu";

    public Fundido fundido;

    public AudioMixer audioMixer;

    public RenderPipelineAsset[] AssetsPipeLine;
    public GameObject Graphics;

    public GameObject MusicToDestroy;

    public Slider VolumenSD;
    public Dropdown GraficsDw;

	public void Start()
	{
        Playerprefs();
    }

    #region Funciones

    public void Playerprefs()
	{
        VolumenSD.value = PlayerPrefs.GetFloat("VolumenPrefs", 0);
        GraficsDw.value = PlayerPrefs.GetInt("GraficosPrefs", 1);
    }

    public void Exit()
    {
        MusicToDestroy = GameObject.Find("Music");
        Destroy(MusicToDestroy);
        fundido.FadeTo(LeveltoLoad);
    }

    public void SetVolume(float volume)
	{
        audioMixer.SetFloat("volume", volume);

        PlayerPrefs.SetFloat("VolumenPrefs", volume);
    }

    public void SetGraphics()
	{
        int graphicsIndex = Graphics.GetComponent<Dropdown>().value;
        GraphicsSettings.renderPipelineAsset = AssetsPipeLine[graphicsIndex];

        PlayerPrefs.SetInt("GraficosPrefs", graphicsIndex);
	}

	public void ResetAllGame()
	{
        PlayerPrefs.DeleteAll();
        Playerprefs();
        SetVolume(VolumenSD.value);
        SetGraphics();
        Debug.Log("Todo eliminado jefe");
        Exit();
    }

	#endregion
}
