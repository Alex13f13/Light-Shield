using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public Fundido fundido;

    public Button[] levelbuttons;

    public GameObject MusicToDestroy;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

		for (int i = 0; i < levelbuttons.Length; i++)
		{
			if (i + 1 > levelReached)
			{
                levelbuttons[i].interactable = false;
            }            
		}
    }

    void Update()
    {
        
    }

    #region Funciones

    public void Select(string levelName)
	{
        MusicToDestroy = GameObject.Find("Music");
        Destroy(MusicToDestroy);
        fundido.FadeTo(levelName);
	}

    #endregion
}
