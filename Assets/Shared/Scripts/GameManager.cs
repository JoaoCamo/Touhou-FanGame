using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject UI;
    public HUD hud;
    
    public int playerLives;
    public int playerBombs;

    private void Start()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            Destroy(UI);
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(UI);
    }
}
