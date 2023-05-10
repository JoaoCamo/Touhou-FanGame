using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletPrefab;
    [ReadOnly] private List<Bullet> bullets = new List<Bullet>();
    private Transform player;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        foreach (Bullet bullet in bullets)
        {
            if (bullet.gameObject.activeSelf)
            {
                bullet.setJob();
            }
        }
    }

    private void LateUpdate()
    {
        foreach (Bullet bullet in bullets)
        {
            if (bullet.gameObject.activeSelf)
            {
                bullet.completeJob();
            }
        }
    }

    public Bullet show(int type, float xSpeed, float ySpeed, Vector3 position, float angle)
    {
        Bullet bulletData = getBullet(type);

        bulletData._positionResult[0] = position;
        bulletData.transform.position = bulletData._positionResult[0];
        bulletData.transform.rotation = Quaternion.Euler(0,0,angle);
        bulletData.type = type;
        bulletData.xSpeed = xSpeed;
        bulletData.ySpeed = ySpeed;
    
        bulletData.Show();
        return bulletData;
    }
    
    public Bullet getBullet(int type)
    {
        Bullet bullet = bullets.Find(t => !t.gameObject.activeSelf && t.type == type);
    
        if(bullet == null)
        {
            bullet = Instantiate(bulletPrefab[type]).GetComponent<Bullet>();
            bullet.allocateMemory();

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
        foreach (Bullet bullet in bullets)
        {
            Destroy(bullet.gameObject);
        }
        bullets.Clear();
    }

    public Transform getPlayerPos()
    {
        return this.player;
    }
}
