using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int playerLifes;
    public int playerBombs;

    private void Start()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        
        DontDestroyOnLoad(gameObject);
    }
}
