using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDanmaku : MonoBehaviour
{
    private float angle;
    private BulletManager bm;

    private void Start()
    {
        bm = GameObject.Find("PoolingManager").transform.GetComponent<BulletManager>();
    }

    private void roundShot()
    {
        angle = 0f;
        for (int i = 0; i < 8; i++)
        {
            bm.show(3, 0f ,1f, transform.position, angle);

            angle += 45;
        }
    }
}
