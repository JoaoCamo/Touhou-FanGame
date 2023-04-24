using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
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
        if(repeats)
        {
            InvokeRepeating("setShot", initalShotDelay, shotDelay);
        } else {
            Invoke("setShot", initalShotDelay);
        }

    }

    private void setShot()
    {
        danmaku.SendMessage(this.danmakuName,this.bulletType);
    }
}
