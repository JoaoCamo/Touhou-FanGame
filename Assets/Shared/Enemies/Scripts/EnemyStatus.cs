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
            GameManager.instance.score += 10;
            GameManager.instance.hud.updateScore();
            return;
        }
        destroy();
    }

    public void destroy()
    {
        if(!dropped)
        {
            float xOffSet = UnityEngine.Random.Range(-0.2f,0.2f);
            float yOffSet = UnityEngine.Random.Range(-0.2f,0.2f);
            Instantiate(drops[0], new Vector3(transform.position.x+xOffSet,transform.position.y+yOffSet,transform.position.z),Quaternion.identity);
            dropped = true;
        }
        Destroy(gameObject);
    }
}
