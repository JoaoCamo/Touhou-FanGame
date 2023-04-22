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
    private bool grazed = false;
    [SerializeField] private bool isBomb;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Barrier"))
        {
            Hide();
            return;
        }

        if(isBomb && col.CompareTag("EnemyBullet"))
        {
            col.GetComponent<Bullet>().Hide();
            return;
        }

        if (col.CompareTag("Enemy") && !isEnemy)
        {
            if(!isBomb)
            {
                col.SendMessage("ReceiveDamage", 1);
                Hide();
            } else {
                col.SendMessage("ReceiveDamage", 15);
            }
        } else if (col.CompareTag("Player") && isEnemy) {
            col.SendMessage("ReceiveDamage");
            Hide();
        } else if (col.CompareTag("Graze") && isEnemy && !grazed) {
            col.transform.parent.SendMessage("Graze");
            grazed = true;
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
        grazed = false;
        gameObject.SetActive(active);
    }
}
