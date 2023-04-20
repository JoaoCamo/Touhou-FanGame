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
            return;
        }

        if (col.CompareTag("Enemy") && !isEnemy)
        {
            col.SendMessage("ReceiveDamage");
            Hide();
            return;
        } else if (col.CompareTag("Player") && isEnemy) {
            col.SendMessage("ReceiveDamage");
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
