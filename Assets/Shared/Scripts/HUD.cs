using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject[] lives;
    [SerializeField] private GameObject[] bombs;
    [SerializeField] private TMPro.TMP_Text pointsText;
    [SerializeField] private TMPro.TMP_Text powerText;
    [SerializeField] private TMPro.TMP_Text grazeText;

    private void Start()
    {
        updateLifes();
        updateBombs();
        updatePoints();
    }

    public void updateLifes()
    {
        for (int i = 0; i < GameManager.instance.playerLives; i++)
        {
            lives[i].SetActive(true);
        }
    }

    public void loseLife(int lifeIndex)
    {
        lives[lifeIndex].SetActive(false);
    }

    public void updateBombs()
    {
        for (int i = 0; i < GameManager.instance.playerBombs; i++)
        {
            bombs[i].SetActive(true);
        }
    }

    public void useBomb(int bombIndex)
    {
        bombs[bombIndex].SetActive(false);
    }

    public void updatePoints()
    {
        pointsText.text = GameManager.instance.points.ToString();
    }

    public void updatePower()
    {
        powerText.text = GameManager.instance.playerPower.ToString("0.00") + " / 4.00";
    }

    public void updateGraze()
    {
        grazeText.text = GameManager.instance.graze.ToString();
    }
}
