using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private bool point;
    [SerializeField] private bool power;
    [SerializeField] private bool life;
    [SerializeField] private bool bomb;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (point)
        {
            return;
        } else if (power) {
            return;
        } else if (life) {
            if (GameManager.instance.playerLives < 8)
            {
                GameManager.instance.playerLives++;
                GameManager.instance.hud.updateLifes();
            } else {
                GameManager.instance.playerBombs++;
            }
        } else if (bomb) {
            GameManager.instance.playerBombs++;
        }
    }
}
