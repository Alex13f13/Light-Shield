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

    #region Funciones

    public void Exit()
    {
        MusicToDestroy = GameObject.Find("Music");
        Destroy(MusicToDestroy);
        fundido.FadeTo(LeveltoLoad);
    }

    public void SetVolume(float volume)
	{
        audioMixer.SetFloat("volume", volume);
	}

    public void SetGraphics()
	{
        int graphicsIndex = Graphics.GetComponent<Dropdown>().value;
        GraphicsSettings.renderPipelineAsset = AssetsPipeLine[graphicsIndex];
        //QualitySettings.SetQualityLevel(qualityIndex);
	}

	public void ResetAllGame()
	{
		PlayerPrefs.DeleteKey("levelReached");
		Debug.Log("Todo eliminado jefe");
	}

	#endregion
}
