using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    [SerializeField] private bool point;
    [SerializeField] private bool power;
    [SerializeField] private bool bigPower;
    [SerializeField] private bool fullPower;
    [SerializeField] private bool life;
    [SerializeField] private bool bomb;
    private bool goToPlayer = false;
    private Vector3 direction;
    private PopUpTextManager popUpTextManager;

    private void Start()
    {
        popUpTextManager = GameObject.Find("PoolingManager").GetComponent<PopUpTextManager>();        
    }

    private void Update()
    {
        if(goToPlayer)
        {
            direction = (GameObject.Find("Player").transform.position - transform.position).normalized;
            transform.Translate(direction.x * 3f * Time.deltaTime, direction.y * 3f * Time.deltaTime, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            if (point)
            {
                getPoints();
            } else if (power) {
                getPower();
            } else if (life) {
                if (GameManager.instance.playerLives < 8)
                {
                    GameManager.instance.playerLives++;
                    GameManager.instance.hud.updateLifes();
                } else {
                    GameManager.instance.playerBombs++;
                    GameManager.instance.hud.updateBombs();
                }
                Destroy(this.gameObject);
            } else if (bomb) {
                GameManager.instance.playerBombs++;
                Destroy(this.gameObject);
            }
        } else if(col.CompareTag("Barrier")) {
            Destroy(this.gameObject);
        }
    }

    private void getPoints()
    {
        int value;
        if(transform.position.y >= 0.7)
        {
            value = 50000 * GameManager.instance.difficulty;
            GameManager.instance.score += value;
            popUpTextManager.show(value.ToString(), 15, Color.yellow, transform.position, Vector3.up * 50, 1f);
        } else {
            if(transform.position.y >= 0 && transform.position.y < 0.7)
            {
                value = (int)(50000 * (transform.position.y+0.3f)) * GameManager.instance.difficulty;
                GameManager.instance.score += value;
            } else {
                value = 12500 * GameManager.instance.difficulty;
                GameManager.instance.score += value;
            }
            popUpTextManager.show(value.ToString(), 15, Color.white, transform.position, Vector3.up * 50, 1f);
        }
        GameManager.instance.hud.updateScore();
        GameManager.instance.checkForNewlife();
        Destroy(this.gameObject);
    }

    private void getPower()
    {
        if(GameManager.instance.playerPower < 4 && !fullPower)
        {
            if(bigPower)
            {
                if(GameManager.instance.playerPower + 0.5f > 4)
                {
                    GameManager.instance.playerPower = 4;
                } else {
                    GameManager.instance.playerPower += 0.5f;
                }
                popUpTextManager.show("100", 15, Color.white, transform.position, Vector3.up * 50, 1f);
                GameManager.instance.score += 100;
            } else {
                GameManager.instance.playerPower += 0.05f;
                popUpTextManager.show("10", 15, Color.white, transform.position, Vector3.up * 50, 1f);
                GameManager.instance.score += 10;
            }
        } else {
            GameManager.instance.playerPower = 4;
            popUpTextManager.show("1000", 15, Color.white, transform.position, Vector3.up * 50, 1f);
            GameManager.instance.score += 1000;
        }
        GameManager.instance.hud.updateScore();
        GameManager.instance.hud.updatePower();
        if(GameManager.instance.playerPower == 4)
        {
            GameObject.Find("PoolingManager").GetComponent<BulletManager>().hideEnemyBullets();
        }
        Destroy(this.gameObject);
    }

    public void getAll()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        goToPlayer = true;
    }
}
