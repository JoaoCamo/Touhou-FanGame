using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] private EnemiesDanmaku danmaku;
    [SerializeField] private string danmakuName;
    [SerializeField] private int bulletType;
    [SerializeField] private float initalShotDelay;
    [SerializeField] private float shotDelay;
    [SerializeField] private bool repeats = false;

    private void Start()
    {
        danmaku = GetComponent<EnemiesDanmaku>();
    }

    public void startShot()
    {
        if(!repeats)
        {
            Invoke(nameof(setShot), initalShotDelay);
        } else {
            Invoke(nameof(repeatShot), initalShotDelay);
        }
    }

    private void repeatShot()
    {
        setShot();
        Invoke(nameof(repeatShot), shotDelay);
    }

    private void setShot()
    {
        danmaku.SendMessage(this.danmakuName,this.bulletType);
    }

    public void setBehaviour(BossAttackData BAD)
    {
        this.danmakuName = BAD.danmakuName;
        this.bulletType = BAD.bulletType;
        this.initalShotDelay = BAD.initalShotDelay;
        this.shotDelay = BAD.shotDelay;
        this.repeats = BAD.repeats;
    }

    public void stopShot()
    {
        CancelInvoke(nameof(repeatShot));
        CancelInvoke(nameof(setShot));
        danmaku.StopAllCoroutines();
    }

    public EnemiesDanmaku getDanmaku()
    {
        return this.danmaku;
    }
    
    public void destroy()
    {
        Destroy(this.gameObject);
    }
}
