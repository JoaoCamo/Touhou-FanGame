using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private GameObject[] drops;
    private bool dropped = false;

    public void ReceiveDamage(int damage)
    {
        if (life > 0)
        {
            life -= damage;
            GameManager.instance.points += 10;
            GameManager.instance.hud.updatePoints();
            return;
        }
        destroy();
    }

    public void destroy()
    {
        if(!dropped)
        {
            Instantiate(drops[0], new Vector3(transform.position.x+0.1f,transform.position.y,transform.position.z),Quaternion.identity);
            Instantiate(drops[0], new Vector3(transform.position.x-0.1f,transform.position.y,transform.position.z),Quaternion.identity);
            Instantiate(drops[1], new Vector3(transform.position.x,transform.position.y+0.1f,transform.position.z),Quaternion.identity);
            dropped = true;
        }
        Destroy(gameObject);
    }
}
