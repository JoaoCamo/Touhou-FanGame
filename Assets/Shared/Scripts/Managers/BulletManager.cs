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
    
    public void show(int type, float xSpeed, float ySpeed, Vector3 position, float angle)
    {
        GameObject bullet = getBullet(type);
    
        bullet.transform.position = position;
        bullet.transform.rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y, angle);
        bullet.GetComponent<Bullet>().type = type;
        bullet.GetComponent<Bullet>().xSpeed = xSpeed;
        bullet.GetComponent<Bullet>().ySpeed = ySpeed;
    
        bullet.GetComponent<Bullet>().Show();
    }
    
    public GameObject getBullet(int type)
    {
        GameObject bullet = bullets.Find(t => !t.activeSelf && t.GetComponent<Bullet>().type == type);
    
        if(bullet == null)
        {
            bullet = Instantiate(bulletPrefab[type]);
    
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
