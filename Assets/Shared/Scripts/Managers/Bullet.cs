using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
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
                col.SendMessage("ReceiveDamage", 30);
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
        transform.Translate(xSpeed*Time.deltaTime,ySpeed*Time.deltaTime,0f);
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        grazed = false;
        gameObject.SetActive(false);
    }
}
