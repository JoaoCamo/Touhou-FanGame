using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] private int life;
    [SerializeField] private GameObject[] drops;
    private bool dropped = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Barrier"))
        {
            Destroy(this.gameObject);
        }
    }

    public void ReceiveDamage(int damage)
    {
        if (life > 0)
        {
            life -= damage;
            GameManager.instance.score += 10;
            GameManager.instance.hud.updateScore();
            return;
        }
        defeated();
    }

    public void defeated()
    {
        if(!dropped)
        {
            for(int i = 0; i<drops.Length; i++)
            {
                float xOffSet = UnityEngine.Random.Range(-0.6f,0.6f);
                float yOffSet = UnityEngine.Random.Range(-0.6f,0.6f);
                Instantiate(drops[i], new Vector3(transform.position.x+xOffSet,transform.position.y+yOffSet,transform.position.z),Quaternion.identity);
            }
            dropped = true;
        }
        destroy();
    }

    public void setHP(int value)
    {
        this.life = value;
    }

    public void destroy()
    {
        Destroy(this.gameObject);
    }
}
