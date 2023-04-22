using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Danmaku : MonoBehaviour
{
    private float angle;
    private BulletManager bm;

    private void Start()
    {
        bm = GameObject.Find("PoolingManager").transform.GetComponent<BulletManager>();
    }
}
