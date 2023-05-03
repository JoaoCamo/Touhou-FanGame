using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletPrefab;
    private List<GameObject> bullets = new List<GameObject>();
    private Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        foreach (GameObject bullet in bullets)
        {
            if (bullet.activeSelf)
            {
                bullet.GetComponent<Bullet>().setJob();
            }
        }
    }

    private void LateUpdate()
    {
        foreach (GameObject bullet in bullets)
        {
            if (bullet.activeSelf)
            {
                bullet.GetComponent<Bullet>().completeJob();
            }
        }
    }

    public void show(int type, float xSpeed, float ySpeed, Vector3 position, float angle)
    {
        GameObject bullet = getBullet(type);
        Bullet bulletData = bullet.GetComponent<Bullet>();
        
        bulletData._positionResult[0] = position;
        bullet.transform.position = bulletData._positionResult[0];
        bullet.transform.rotation = Quaternion.Euler(0,0,angle);
        bulletData.type = type;
        bulletData.xSpeed = xSpeed;
        bulletData.ySpeed = ySpeed;
    
        bulletData.Show();
    }
    
    public GameObject getBullet(int type)
    {
        GameObject bullet = bullets.Find(t => !t.activeSelf && t.GetComponent<Bullet>().type == type);
    
        if(bullet == null)
        {
            bullet = Instantiate(bulletPrefab[type]);
            bullet.GetComponent<Bullet>().allocateMemory();
    
            bullets.Add(bullet);
        }
    
        return bullet;
    }

    public void hideEnemyBullets()
    {
        foreach (Bullet bullet in FindObjectsOfType<Bullet>())
        {
            if(bullet.CompareTag("EnemyBullet"))
            {
                bullet.Hide();
            }
        }
    }

    public void clearBullets()
    {
        bullets.Clear();
        foreach (Bullet bullet in FindObjectsOfType<Bullet>())
        {
            Destroy(bullet.gameObject);
        }
    }

    public Transform getPlayerPos()
    {
        return this.player;
    }
}
