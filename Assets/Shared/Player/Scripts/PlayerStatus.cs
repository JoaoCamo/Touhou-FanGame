using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float immuneTime = 2f;
    private float lastImmune = 0f;
    
    private void ReceiveDamage()
    {
        if (GameManager.instance.playerLives > 0 && (Time.time - lastImmune) > immuneTime)
        {
            lastImmune = Time.time;
            GameManager.instance.hud.loseLife(GameManager.instance.playerLives-1);
            GameManager.instance.playerLives -= 1;
            GameManager.instance.playerBombs = 2;
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
