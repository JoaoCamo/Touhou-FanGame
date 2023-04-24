using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject UI;
    public HUD hud;
    
    public int pointsToNextLife = 50;
    public int pointsCollected;
    public int difficulty;
    public int score;
    public int playerLives;
    public int playerBombs;
    public int graze;
    public float playerPower;

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

    public void checkForNewlife()
    {
        pointsCollected++;
        if(pointsCollected >= pointsToNextLife)
        {
            if(playerLives < 8)
            {
                playerLives++;
                hud.updateLifes();
            } else {
                playerBombs++;
                hud.updateBombs();
            }
            pointsToNextLife*=2;
        }
        hud.updatePoints();

    }
}
