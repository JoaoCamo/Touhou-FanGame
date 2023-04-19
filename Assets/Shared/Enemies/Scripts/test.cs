using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private BulletManager bm;
    private float angle;
    
    private void Start()
    {
        bm = GameObject.Find("BulletManager").transform.GetComponent<BulletManager>();
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
        for (int i = 1; i < 2 + 1; i++)
        {
            bm.show(1, 0f, 0.5f,transform.position, angle);

            if (i == 2)
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
