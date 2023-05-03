using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private BulletManager bm;
    private float bombCooldown = 3f;
    private float lastBomb;
    private bool bombed = false;
    private PlayerMovement pm;
    private Vector3 shotOrigin;
    [SerializeField] private Animator bombAni;
    [SerializeField] private InputAction shootInput;
    [SerializeField] private InputAction bombInput;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
        if (bm = GameObject.Find("PoolingManager").GetComponent<BulletManager>())
        {
            bombAni = GameObject.Find("BombAnimationMarisa").GetComponent<Animator>();
            shootInput.Enable();
            bombInput.Enable();
            shootInput.performed += startShoot;
            shootInput.canceled += endShoot;
            bombInput.performed += useBomb;
        }
    }

    private void startShoot(InputAction.CallbackContext context)
    {
        if(!bombed)
        {
            InvokeRepeating("mainShot",0f,0.075f);
            InvokeRepeating("shotMissile",0f,0.1f);
        }
    }

    private void endShoot(InputAction.CallbackContext context)
    {
        CancelInvoke("mainShot");
        CancelInvoke("shotMissile");
    }

    private void mainShot()
    {
        shotOrigin = transform.position;
        bm.show(0,8f,0f,new Vector3(shotOrigin.x + 0.075f,shotOrigin.y, 0),90f);
        bm.show(0,8f,0f,new Vector3(shotOrigin.x - 0.075f,shotOrigin.y, 0),90f);
    }

    private void shotMissile()
    {
        if(GameManager.instance.playerPower >= 1)
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
    }

    private void missileShot1()
    {
        shotOrigin = transform.position;
        bm.show(1,6.5f,0f,new Vector3(shotOrigin.x,shotOrigin.y + 0.3f, 0),90f);
    }

    private void missileShot2()
    {
        shotOrigin = transform.position;
        if(gameObject.GetComponent<PlayerMovement>().getFocus())
        {
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x + 0.2f,shotOrigin.y, 0),90f);
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x - 0.2f,shotOrigin.y, 0),90f);
        } else {
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x + 0.3f,shotOrigin.y, 0),90f);
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x - 0.3f,shotOrigin.y, 0),90f);
        }
    }

    private void missileShot3()
    {
        shotOrigin = transform.position;
        if(gameObject.GetComponent<PlayerMovement>().getFocus())
        {
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x + 0.2f,shotOrigin.y + 0.3f,0),90f);
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x - 0.2f,shotOrigin.y + 0.3f,0),90f);
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x,shotOrigin.y + 0.3f,0),90f);
        } else {
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x + 0.3f,shotOrigin.y, 0),90f);
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x - 0.3f,shotOrigin.y, 0),90f);
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x,shotOrigin.y + 0.3f, 0),90f);
        }
    }

    private void missileShot4()
    {
        shotOrigin = transform.position;
        if(gameObject.GetComponent<PlayerMovement>().getFocus())
        {
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x + 0.2f,shotOrigin.y, 0),90f);
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x - 0.2f,shotOrigin.y, 0),90f);
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x + 0.125f,shotOrigin.y + 0.3f, 0),90f);
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x - 0.125f,shotOrigin.y + 0.3f, 0),90f);
        } else {
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x + 0.3f,shotOrigin.y, 0),90f);
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x - 0.3f,shotOrigin.y, 0),90f);
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x + 0.175f,shotOrigin.y + 0.3f, 0),90f);
            bm.show(1,6.5f,0f,new Vector3(shotOrigin.x - 0.175f,shotOrigin.y + 0.3f, 0),90f);
        }
    }

    private void useBomb(InputAction.CallbackContext context)
    {
        if(GameManager.instance.playerBombs > 0 && (Time.time - lastBomb) > bombCooldown)
        {
            gameObject.GetComponent<PlayerStatus>().setLastImmune(Time.time);
            lastBomb = Time.time;
            float angle = UnityEngine.Random.Range(0f,360f);
            for (int i = 0; i < 9; i++)
            {
                bm.show(2,0f,1.25f, transform.position, angle);
                angle += 45;
            }
            GameManager.instance.playerBombs--;
            GameManager.instance.hud.useBomb(GameManager.instance.playerBombs);
            bombAni.SetTrigger("bomb");
            GetComponent<Animator>().SetTrigger("blink");
            StartCoroutine(bombSlowDown());
            getAll();
        }
    }

    private IEnumerator bombSlowDown()
    {
        bombed = true;
        if(!pm.getFocus())
        {
            pm.setSpeed(pm.getSpeed()/2);
        }
        yield return new WaitForSeconds(2f);
        bombed = false;
        if(!pm.getFocus())
        {
            pm.setSpeed(pm.getSpeed());
        }
    }

    public void getAll()
    {
        foreach (Collectables collectables in FindObjectsOfType<Collectables>())
        {
            collectables.getAll();
        }
    }

    public bool getBombed()
    {
        return this.bombed;
    }
}
