using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private BulletManager bm;
    private float bombTime = 3f;
    private float lastBomb;
    [SerializeField] private InputAction shootInput;
    [SerializeField] private InputAction bombInput;
    private void Start()
    {
        if (bm = GameObject.Find("PoolingManager").GetComponent<BulletManager>())
        {
            shootInput.Enable();
            bombInput.Enable();
            shootInput.performed += startShoot;
            shootInput.canceled += endShoot;
            bombInput.performed += useBomb;
        }
    }

    private void startShoot(InputAction.CallbackContext context)
    {
        InvokeRepeating("mainShot",0f,0.05f);
        if(GameManager.instance.playerPower >= 1)
        {
            InvokeRepeating("shotMissile",0f,0.15f);
        }
    }

    private void endShoot(InputAction.CallbackContext context)
    {
        CancelInvoke("mainShot");
        CancelInvoke("shotMissile");
    }

    private void mainShot()
    {
        bm.show(0,0.2f,0f,new Vector3(transform.position.x + 0.075f,transform.position.y, transform.position.z),90f);
        bm.show(0,0.2f,0f,new Vector3(transform.position.x - 0.075f,transform.position.y, transform.position.z),90f);
    }

    private void shotMissile()
    {
        if(GameManager.instance.playerPower == 4)
        {
            missileShot4();
        } else if(GameManager.instance.playerPower >= 3) {
            missileShot3();
        } else if(GameManager.instance.playerPower >= 2) {
            missileShot2();
        } else {
            missileShot1();
        }
    }

    private void missileShot1()
    {
        bm.show(1,0.15f,0f,new Vector3(transform.position.x,transform.position.y + 0.3f, transform.position.z),90f);
    }

    private void missileShot2()
    {
        if(gameObject.GetComponent<PlayerMovement>().getFocus())
        {
            bm.show(1,0.15f,0f,new Vector3(transform.position.x + 0.2f,transform.position.y, transform.position.z),90f);
            bm.show(1,0.15f,0f,new Vector3(transform.position.x - 0.2f,transform.position.y, transform.position.z),90f);
        } else {
            bm.show(1,0.15f,0f,new Vector3(transform.position.x + 0.3f,transform.position.y, transform.position.z),90f);
            bm.show(1,0.15f,0f,new Vector3(transform.position.x - 0.3f,transform.position.y, transform.position.z),90f);
        }
    }

    private void missileShot3()
    {
        if(gameObject.GetComponent<PlayerMovement>().getFocus())
        {
            bm.show(1,0.15f,0f,new Vector3(transform.position.x + 0.2f,transform.position.y + 0.3f, transform.position.z),90f);
            bm.show(1,0.15f,0f,new Vector3(transform.position.x - 0.2f,transform.position.y + 0.3f, transform.position.z),90f);
            bm.show(1,0.15f,0f,new Vector3(transform.position.x,transform.position.y + 0.3f, transform.position.z),90f);
        } else {
            bm.show(1,0.15f,0f,new Vector3(transform.position.x + 0.3f,transform.position.y, transform.position.z),90f);
            bm.show(1,0.15f,0f,new Vector3(transform.position.x - 0.3f,transform.position.y, transform.position.z),90f);
            bm.show(1,0.15f,0f,new Vector3(transform.position.x,transform.position.y + 0.3f, transform.position.z),90f);
        }
    }

    private void missileShot4()
    {
        if(gameObject.GetComponent<PlayerMovement>().getFocus())
        {
            bm.show(1,0.15f,0f,new Vector3(transform.position.x + 0.2f,transform.position.y, transform.position.z),90f);
            bm.show(1,0.15f,0f,new Vector3(transform.position.x - 0.2f,transform.position.y, transform.position.z),90f);
            bm.show(1,0.15f,0f,new Vector3(transform.position.x + 0.125f,transform.position.y + 0.3f, transform.position.z),90f);
            bm.show(1,0.15f,0f,new Vector3(transform.position.x - 0.125f,transform.position.y + 0.3f, transform.position.z),90f);
        } else {
            bm.show(1,0.15f,0f,new Vector3(transform.position.x + 0.3f,transform.position.y, transform.position.z),90f);
            bm.show(1,0.15f,0f,new Vector3(transform.position.x - 0.3f,transform.position.y, transform.position.z),90f);
            bm.show(1,0.15f,0f,new Vector3(transform.position.x + 0.175f,transform.position.y + 0.3f, transform.position.z),90f);
            bm.show(1,0.15f,0f,new Vector3(transform.position.x - 0.175f,transform.position.y + 0.3f, transform.position.z),90f);
        }
    }

    private void useBomb(InputAction.CallbackContext context)
    {
        if(GameManager.instance.playerBombs > 0 && (Time.time - lastBomb) > bombTime)
        {
            lastBomb = Time.time;
            float angle = UnityEngine.Random.Range(0f,360f);
            for (int i = 0; i < 6; i++)
            {
                bm.show(2,0.05f,0.25f, transform.position, angle);

                angle += 72;
            }
            GameManager.instance.playerBombs--;
            GameManager.instance.hud.useBomb(GameManager.instance.playerBombs);
        }
    }
}
