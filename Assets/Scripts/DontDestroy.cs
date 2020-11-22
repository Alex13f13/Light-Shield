using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy instance;

    public void Awake()
	{
		if (instance == null)
		{
            instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
