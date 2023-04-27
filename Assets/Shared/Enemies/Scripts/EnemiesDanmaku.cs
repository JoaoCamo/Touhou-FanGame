using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDanmaku : MonoBehaviour
{
    private float angle;
    private int i;
    private BulletManager bm;
    private Vector3 vectorToTarget;
    private Vector3 shotOrigin;

    private void Start()
    {
        bm = GameObject.Find("PoolingManager").transform.GetComponent<BulletManager>();
    }

    public void roundShot4(int type)
    {
        shotOrigin = transform.position;
        vectorToTarget = bm.getPlayerPos().position - shotOrigin;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 180f;
        for (i = 0; i < 4; i++)
        {
            bm.show(type, 0f, 1f, shotOrigin, angle);
            angle += 90;
        }
    }

    public void roundShot16(int type)
    {
        vectorToTarget = bm.getPlayerPos().position - transform.position;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 180f;
        for (i = 0; i < 16; i++)
        {
            bm.show(type, 0f, 1f, transform.position, angle);
            angle += 22.5f;
        }
    }

    public void doubleRoundShot16(int type)
    {
        shotOrigin = transform.position;
        vectorToTarget = bm.getPlayerPos().position - shotOrigin;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 180f;
        for (i = 0; i < 16; i++)
        {
            bm.show(type, 0f, 0.8f, shotOrigin, angle);
            bm.show(type, 0f, 1f, shotOrigin, angle);
            angle += 22.5f;
        }
    }

    public void halfMoon(int type)
    {
        shotOrigin = transform.position;
        vectorToTarget = bm.getPlayerPos().position - shotOrigin;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 180f;
        for (i = 0; i < 9; i++)
        {
            bm.show(type, 0f, 1f, shotOrigin, angle);
            angle += 22.5f;
        }
    }

    public void doubleHalfMoon(int type)
    {
        shotOrigin = transform.position;
        vectorToTarget = bm.getPlayerPos().position - shotOrigin;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 180f;
        for (i = 0; i < 9; i++)
        {
            bm.show(type, 0f, 0.8f, shotOrigin, angle);
            bm.show(type, 0f, 1f, shotOrigin, angle);
            angle += 22.5f;
        }
    }

    public IEnumerator roundShotProgressiveRoutine(int type)
    {
        angle = 0;
        float angelStep = 5;
        for (i = 0; i < 150; i++)
        {
            yield return new WaitForSeconds(0.05f);
            shotOrigin = transform.position;
            bm.show(type, 0f, 1f, shotOrigin, angle);
            bm.show(type, 0f, 1f, shotOrigin, angle + 120f);
            bm.show(type, 0f, 1f, shotOrigin, angle + 240f);
            angle += 10f;
            if (i >= 50)
            {
                bm.show(type, 0f, 0.8f, shotOrigin, angle + angelStep);
                bm.show(type, 0f, 0.8f, shotOrigin, angle + 120f + angelStep);
                bm.show(type, 0f, 0.8f, shotOrigin, angle + 240f + angelStep);
            }
        }
    }

    public void roundShotProgressive(int type)
    {
        StartCoroutine(roundShotProgressiveRoutine(type));
    }

    public IEnumerator roundShotPlusConeRoutine()
    {
        roundShot16(5);
        vectorToTarget = bm.getPlayerPos().position - shotOrigin;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 95f;
        for (i = 0; i < 10; i++)
        {
            shotOrigin = transform.position;
            yield return new WaitForSeconds(0.125f);
            bm.show(6, 0f, 1f, shotOrigin, angle);
            bm.show(6, 0f, 1f, shotOrigin, angle+5);
            bm.show(6, 0f, 1f, shotOrigin, angle+10);
        }
    }

    public void roundShotPlusCone()
    {
        StartCoroutine(roundShotPlusConeRoutine());
    }
}
