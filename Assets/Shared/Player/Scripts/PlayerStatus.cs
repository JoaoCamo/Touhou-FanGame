using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public void receiveDamage(int damage)
    {
        if (GameManager.instance.playerLifes > 0)
        {
            GameManager.instance.playerLifes -= damage;
            //hitted();
            return;
        }
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
