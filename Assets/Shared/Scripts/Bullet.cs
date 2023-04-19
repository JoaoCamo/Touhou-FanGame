using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public bool active;
    public int type;
    public float ySpeed;
    public float xSpeed;
    public bool isEnemy = true;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Barrier"))
        {
            Hide();
        }

        if (col.CompareTag("Player") && isEnemy)
        {
            if (GameManager.instance.playerLifes > 0)
            {
                col.SendMessage("receiveDamage",1);
                Hide();
                return;
            }
            Hide();
        }

        if (col.CompareTag("Enemy") && !isEnemy)
        {
            col.SendMessage("receiveDamage",1);
            Hide();
        }
    }

    private void FixedUpdate()
    {
        transform.Translate( xSpeed,ySpeed * Time.deltaTime,0f);
    }
    
    public void Show()
    {
        active = true;
        gameObject.SetActive(active);
    }
    
    public void Hide()
    {
        active = false;
        gameObject.SetActive(active);
    }
}
