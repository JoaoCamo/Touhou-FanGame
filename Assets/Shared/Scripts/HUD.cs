using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject[] images;

    private void Start()
    {
        updateLifes();
    }

    public void updateLifes()
    {
        for (int i = 0; i < GameManager.instance.playerLives; i++)
        {
            images[i].SetActive(true);
        }
    }

    public void loseLife(int lifeNumber)
    {
        images[lifeNumber].SetActive(false);
    }
}
