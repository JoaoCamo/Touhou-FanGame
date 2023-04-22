using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private BulletManager bm;
    private float angle;
    
    private void Start()
    {
        bm = GameObject.Find("PoolingManager").transform.GetComponent<BulletManager>();
        StartCoroutine(Fire());
    }
    
    private IEnumerator Fire()
    {
        int count = 0;
        while (count < 50) 
        { 
            yield return new WaitForSeconds(0.1f);
            shot4();
            count++;
        }
        StartCoroutine(Fire());
    }

    private void shot4()
    {
        for (int i = 1; i < 4; i++)
        {
            bm.show(3, 0f, 0.75f,transform.position, angle);

            if (i == 3)
            {
                angle += 20f;
            }
            else
            {
                angle += 120f;
            }
        }
    }
}
