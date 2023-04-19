using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private int life;

    public void receiveDamage(int damage)
    {
        if (life > 0)
        {
            life -= damage;
            return;
        }
        destroy();
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
