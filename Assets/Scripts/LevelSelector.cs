using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public Fundido fundido;

    public Button[] levelbuttons;

    public Sprite[] Stars;

    public GameObject MusicToDestroy;

    public int AllStars;

    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);       

        for (int i = 0; i < levelbuttons.Length; i++)
		{
			if (i + 1 > levelReached)
			{
                levelbuttons[i].interactable = false;                
            }
            levelbuttons[i].GetComponent<BotonesFunciones>().starsAmount = GetStar(i + 1);
            AllStars += GetStar(i + 1);           
        }
        if (AllStars >= 30)
        {
            levelbuttons[10].interactable = true;
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

    public Sprite SetStartSprite(int starAmount, Image image)
	{
		switch (starAmount)
		{
            case 0:
                image.sprite = Stars[starAmount];
                break;
            
            case 1:
                image.sprite = Stars[starAmount];
                break;

            case 2:
                image.sprite = Stars[starAmount];
                break;

            case 3:
                image.sprite = Stars[starAmount];
                break;
        }
        return image.sprite;
    }

    private string GetKey(int Level)
    {
        return "Level_"+Level+"_Star";
    }

    private int GetStar(int Level)
    {
        return PlayerPrefs.GetInt(GetKey(Level));
    }

    #endregion
}
