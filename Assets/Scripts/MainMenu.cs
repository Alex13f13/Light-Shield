using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class MainMenu : MonoBehaviour
{
    public string LeveltoLoad = "GamePlay";

    public Fundido fundido;

    public AudioMixer audioMixer;

    public RenderPipelineAsset[] AssetsPipeLine;

    #region Funciones

    public void Start()
    {
        GraphicsSettings.renderPipelineAsset = AssetsPipeLine[PlayerPrefs.GetInt("GraficosPrefs", 1)];
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("VolumenPrefs", 0));
    }

    public void Play()
    {
        fundido.FadeTo(LeveltoLoad);
    }

    public void Options()
    {
        fundido.FadeTo("OptionsMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    #endregion
}
