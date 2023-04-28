using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using Unity.Jobs;
using Unity.VisualScripting;

public class Bullet : MonoBehaviour
{
    public int type;
    public float ySpeed;
    public float xSpeed;
    public bool isEnemy = true;
    private bool grazed = false;
    [SerializeField] private bool isBomb;
    
    public NativeArray<Vector2> _positionResult;
    private JobHandle _jobHandle;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Barrier"))
        {
            Hide();
            return;
        }

        if(isBomb && col.CompareTag("EnemyBullet"))
        {
            col.GetComponent<Bullet>().Hide();
            return;
        }

        if (col.CompareTag("Enemy") && !isEnemy)
        {
            if(!isBomb)
            {
                col.SendMessage("ReceiveDamage", 1);
                Hide();
            } else {
                col.SendMessage("ReceiveDamage", 30);
            }
        } else if (col.CompareTag("Player") && isEnemy) {
            col.SendMessage("ReceiveDamage");
            Hide();
        } else if (col.CompareTag("Graze") && isEnemy && !grazed) {
            col.transform.parent.SendMessage("Graze");
            grazed = true;
        }
    }

    private void Update()
    {
        BulletJob job = new BulletJob(ySpeed, xSpeed, Time.deltaTime, transform.position, transform.rotation, _positionResult);
        _jobHandle = job.Schedule();
    }

    private void LateUpdate()
    {
        _jobHandle.Complete();
        transform.position = _positionResult[0];
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        grazed = false;
        gameObject.SetActive(false);
    }

    public void allocateMemory()
    {
        _positionResult = new NativeArray<Vector2>(1, Allocator.Persistent);
    }

    private void OnDestroy()
    {
        _positionResult.Dispose();
    }
}