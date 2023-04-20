using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private BulletManager bm;
    [SerializeField] private InputAction shootInput;
    private void Start()
    {
        if (bm = GameObject.Find("BulletManager").transform.GetComponent<BulletManager>())
        {
            shootInput.Enable();
            shootInput.performed += startShoot;
            shootInput.canceled += endShoot;
        }
    }

    private void startShoot(InputAction.CallbackContext context)
    {
        InvokeRepeating("shoot",0f,0.05f);
    }

    private void endShoot(InputAction.CallbackContext context)
    {
        CancelInvoke("shoot");
    }

    private void shoot()
    {
        bm.show(0,0.25f,0f,new Vector3(transform.position.x + 0.05f,transform.position.y, transform.position.z),90f);
        bm.show(0,0.25f,0f,new Vector3(transform.position.x - 0.05f,transform.position.y, transform.position.z),90f);
    }
}
