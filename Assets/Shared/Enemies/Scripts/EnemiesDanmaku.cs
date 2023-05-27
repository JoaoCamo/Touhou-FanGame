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

    public void singleShot(int type)
    {
        shotOrigin = transform.position;
        vectorToTarget = bm.getPlayerPos().position - shotOrigin;
        angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;
        bm.show(type, 0f, 0.75f, shotOrigin, angle);
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
        for (i = 0; i < 75; i++)
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

    private IEnumerator bowp1(int type, float value, float angle)
    {
        this.angle = angle;
        shotOrigin = transform.position;
        for (i = 0; i < 400; i++)
        {
            yield return new WaitForSeconds(0.0275f);
            bm.show(type, 0f, 1.8f, shotOrigin, angle);
            bm.show(type, 0f, 1.8f, shotOrigin, angle + 45f);
            bm.show(type, 0f, 1.8f, shotOrigin, angle + 90f);
            bm.show(type, 0f, 1.8f, shotOrigin, angle + 135f);
            bm.show(type, 0f, 1.8f, shotOrigin, angle + 180f);
            bm.show(type, 0f, 1.8f, shotOrigin, angle + 225f);
            bm.show(type, 0f, 1.8f, shotOrigin, angle + 270f);
            bm.show(type, 0f, 1.8f, shotOrigin, angle + 315f);
            angle += value + ((i-100) * 0.15f);
        }
    }
    
    private IEnumerator bowp2(int type, float value)
    {
        for (i = 0; i < 125; i++)
        {
            yield return new WaitForSeconds(0.0275f);
            bm.show(type, 0f, 1.8f, shotOrigin, angle);
            bm.show(type, 0f, 1.8f, shotOrigin, angle + 45f);
            bm.show(type, 0f, 1.8f, shotOrigin, angle + 90f);
            bm.show(type, 0f, 1.8f, shotOrigin, angle + 135f);
            bm.show(type, 0f, 1.8f, shotOrigin, angle + 180f);
            bm.show(type, 0f, 1.8f, shotOrigin, angle + 225f);
            bm.show(type, 0f, 1.8f, shotOrigin, angle + 270f);
            bm.show(type, 0f, 1.8f, shotOrigin, angle + 315f);
            angle += value;
        }
    }

    private IEnumerator borderOfWaveAndParticle(int type)
    {
        yield return bowp1(type,10f, -45f);
        yield return bowp2(type,-8.5f);
        yield return bowp1(type,-10, angle);
        yield return bowp2(type,8f);
        yield return bowp1(type,10f, angle);
        StartCoroutine(borderOfWaveAndParticle(type));
    }

    private IEnumerator cirnoPerfectFreeze(int type)
    {
        List<Bullet> bullets = new List<Bullet>();
        for (i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.04f);
            shotOrigin = transform.position;
            angle = Random.Range(90f, 270f);
            bullets.Add(bm.show(type, 0f, 1.5f, shotOrigin, angle));
            angle = Random.Range(90f, 270f);
            bullets.Add(bm.show(type, 0f, 1.5f, shotOrigin, angle));
            angle = Random.Range(90f, 270f);
            bullets.Add(bm.show(type, 0f, 1.5f, shotOrigin, angle));
        }
        yield return new WaitForSeconds(0.5f);
        foreach (Bullet bullet in bullets)
        {
            if(bullet.gameObject.activeSelf) bullet.ySpeed = 0f;
        }
        yield return new WaitForSeconds(2f);
        foreach (Bullet bullet in bullets)
        {
            if (bullet.gameObject.activeSelf)
            {
                angle = Random.Range(0f, 360f);
                bullet.transform.rotation = Quaternion.Euler(0,0,angle);
                bullet.ySpeed = 0.6f;
            }
        }
        yield return new WaitForSeconds(4f);
        bullets.Clear();
        StartCoroutine(cirnoPerfectFreeze(type));
    }

    public IEnumerator sakuyaMidbossRoutine(bool delay = true)
    {
        angle = -270f;
        for (i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.075f);
            shotOrigin = transform.position;
            float ySpeed = 1f;
            for (int j = 0; j < 3; j++)
            {
                bm.show(3, 0f, ySpeed, shotOrigin, angle);
                bm.show(3, 0f, ySpeed, shotOrigin, angle + 1.5f);
                bm.show(3, 0f, ySpeed, shotOrigin, angle + 3);
                bm.show(3, 0f, ySpeed, shotOrigin, angle + 4.5f);
                bm.show(3, 0f, ySpeed, shotOrigin, angle + 6);
                ySpeed -= 0.15f;
            }

            angle += 18;
        }
        if(delay) yield return new WaitForSeconds(0.4f);
        angle = -315f;
        for (i = 0; i < 18; i++)
        {
            yield return new WaitForSeconds(0.11f);
            shotOrigin = transform.position;
            float ySpeed = 1.75f;
            float angleStep = 10f + i;
            for (int j = 0; j < 8; j++)
            {
                bm.show(9, 0f, ySpeed, shotOrigin, angle + angleStep);
                angleStep += 10f;
            }

            angle += 10f;
        }
        yield return new WaitForSeconds(1.25f);
        if(delay) StartCoroutine(sakuyaMidbossRoutine(false));
        else StartCoroutine(sakuyaMidbossRoutine());
    }
    
    public void sakuyaMidboss()
    {
        StartCoroutine(sakuyaMidbossRoutine());
    }
    
    public IEnumerator sakuyaTimeStop()
        {
            shotOrigin = transform.position;
            angle = 0f;
            float ySpeed = 0.8f;
            List<Bullet> bullets = new List<Bullet>();
            for (i = 0; i < 4; i++)
            {
                yield return new WaitForSeconds(0.25f);
                for (int j = 0; j < 54; j++)
                {
                    bullets.Add(bm.show(9, 0f, ySpeed, shotOrigin, angle));
                    angle += (360f/54f);
                }
                ySpeed -= 0.125f;
            }
            angle = 0f;
            yield return new WaitForSeconds(0.25f);
            for (i = 0; i < 8; i++)
            {
                yield return new WaitForSeconds(0.005f);
                ySpeed = 0.8f;
                for (int j = 0; j < 4; j++)
                {
                    yield return new WaitForSeconds(0.005f);
                    bullets.Add(bm.show(3, 0f, ySpeed, shotOrigin, angle));
                    bullets.Add(bm.show(3, 0f, ySpeed, shotOrigin, angle+5));
                    bullets.Add(bm.show(3, 0f, ySpeed, shotOrigin, angle-5));
                    ySpeed -= 0.125f;
                }
                angle += 360f / 8f;
            }
            yield return new WaitForSeconds(1f);
            Time.timeScale = 0f;
            foreach (Bullet bullet in bullets)
            {
                if (bullet.gameObject.activeSelf)
                {
                    yield return new WaitForSecondsRealtime(0.0025f);
                    angle = Random.Range(0f, 360f);
                    bullet.transform.rotation = Quaternion.Euler(0,0,angle);
                }
            }
            Time.timeScale = 1;
            bullets.Clear();
            yield return new WaitForSeconds(2f);
            StartCoroutine(sakuyaTimeStop());
        }
}
