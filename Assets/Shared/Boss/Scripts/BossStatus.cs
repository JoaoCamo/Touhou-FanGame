using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStatus : MonoBehaviour
{
    [SerializeField] private int maxLife;
    [SerializeField] private int life;
    [SerializeField] private int healthBars;

    [SerializeField] private BossAttackData[] shotTypes;

    private BulletManager bm;
    
    private BossBehaviour BB;

    private void Start()
    {
        life = maxLife;

        bm = GameObject.Find("PoolingManager").transform.GetComponent<BulletManager>();
        
        if(BB = GetComponent<BossBehaviour>()) setNewShot();
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
    
    private void defeated()
    {
        if (healthBars-1 > 0)
        {
            healthBars--;
            life = maxLife;
            BB.stopShot();
            bm.clearBullets();
            setNewShot();
        } else {
            Destroy(this.gameObject);
        }
    }
    
    private void setNewShot()
    {
        BB.setBehaviour(shotTypes[healthBars-1]);
        BB.startShot();
    }
}
