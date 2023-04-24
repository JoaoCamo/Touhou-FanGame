using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDanmaku : MonoBehaviour
{
    private float angle;
    private int i;
    private BulletManager bm;

    private void Start()
    {
        bm = GameObject.Find("PoolingManager").transform.GetComponent<BulletManager>();
    }

    public void roundShot4(int type)
    {
        angle = 0f;
        for ( i = 0; i < 4; i++)
        {
            bm.show(type, 0f ,1f, transform.position, angle);
            angle += 90;
        }
    }

    public void roundShot8(int type)
    {
        angle = 0f;
        for ( i = 0; i < 8; i++)
        {
            bm.show(type, 0f ,1f, transform.position, angle);
            angle += 45;
        }
    }

    public void halfMoon(int type)
    {
        angle = 90f;
        for ( i = 0; i < 9; i++)
        {
            bm.show(type, 0f ,1f, transform.position, angle);
            angle += 22.5f;
        }
    }

    public void doubleHalfMoon(int type)
    {
        angle = 90f;
        for ( i = 0; i < 9; i++)
        {
            bm.show(type, 0f ,0.8f, transform.position, angle);
            bm.show(type, 0f ,1f, transform.position, angle);
            angle += 22.5f;
        }
    }

    public IEnumerator roundShotProgressiveRoutine(int type)
    {
        angle = 0;
        for( i = 0; i < 200; i++)
        {
            yield return new WaitForSeconds(0.05f);
            bm.show(type, 0f ,1f, transform.position, angle);
            bm.show(type, 0f ,1f, transform.position, angle+120f);
            bm.show(type, 0f ,1f, transform.position, angle+240f);
            angle+=10f;
            if(i >= 50)
            {
                bm.show(type, 0f ,0.8f, transform.position, angle+5f);
                bm.show(type, 0f ,0.8f, transform.position, angle+120f+5f);
                bm.show(type, 0f ,0.8f, transform.position, angle+240f+5f);
            }
        }
    }

    public void roundShotProgressive(int type)
    {
        StartCoroutine(roundShotProgressiveRoutine(type));
    }
}
