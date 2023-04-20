using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private int life;

    public void ReceiveDamage()
    {
        if (life > 0)
        {
            life -= 1;
            return;
        }
        destroy();
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
