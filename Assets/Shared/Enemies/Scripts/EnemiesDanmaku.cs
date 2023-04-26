using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDanmaku : MonoBehaviour
{
    private float angle;
    private int i;
    private BulletManager bm;
    private Vector3 vectorToTarget;

    private void Start()
    {
        bm = GameObject.Find("PoolingManager").transform.GetComponent<BulletManager>();
    }

    public void roundShot4(int type)
    {
        vectorToTarget = bm.getPlayerPos().position - transform.position;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 180f;
        for ( i = 0; i < 4; i++)
        {
            bm.show(type, 0f ,1f, transform.position, angle);
            angle += 90;
        }
    }

    public void roundShot8(int type)
    {
        vectorToTarget = bm.getPlayerPos().position - transform.position;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 180f;
        for ( i = 0; i < 8; i++)
        {
            bm.show(type, 0f ,1f, transform.position, angle);
            angle += 45;
        }
    }

    public void doubleRoundShot16(int type)
    {
        vectorToTarget = bm.getPlayerPos().position - transform.position;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 180f;
        for ( i = 0; i < 16; i++)
        {
            bm.show(type, 0f ,0.8f, transform.position, angle);
            bm.show(type, 0f ,1f, transform.position, angle);
            angle += 22.5f;
        }
    }

    public void halfMoon(int type)
    {
        vectorToTarget = bm.getPlayerPos().position - transform.position;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 180f;
        for ( i = 0; i < 9; i++)
        {
            bm.show(type, 0f ,1f, transform.position, angle);
            angle += 22.5f;
        }
    }

    public void doubleHalfMoon(int type)
    {
        vectorToTarget = bm.getPlayerPos().position - transform.position;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 180f;
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
        float angelStep = 5;
        for( i = 0; i < 150; i++)
        {
            yield return new WaitForSeconds(0.05f);
            bm.show(type, 0f ,1f, transform.position, angle);
            bm.show(type, 0f ,1f, transform.position, angle+120f);
            bm.show(type, 0f ,1f, transform.position, angle+240f);
            angle+=10f;
            if(i >= 50)
            {
                bm.show(type, 0f ,0.8f, transform.position, angle+angelStep);
                bm.show(type, 0f ,0.8f, transform.position, angle+120f+angelStep);
                bm.show(type, 0f ,0.8f, transform.position, angle+240f+angelStep);
            }
        }
    }

    public void roundShotProgressive(int type)
    {
        StartCoroutine(roundShotProgressiveRoutine(type));
    }
}
