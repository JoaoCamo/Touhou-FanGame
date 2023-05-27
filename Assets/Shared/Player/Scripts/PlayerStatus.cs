using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float immuneTime = 4f;
    private float lastImmune = 0f;
    private PlayerMovement pm;
    private PlayerAttack pa;

    [SerializeField] GameObject[] missDropsPrefabs;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }
    
    private void ReceiveDamage()
    {
        if (GameManager.instance.playerLives > 0 && (Time.time - lastImmune) > immuneTime)
        {
            lastImmune = Time.time;
            GameManager.instance.hud.loseLife(GameManager.instance.playerLives-1);
            missPowerLoss();
            missPowerDrops();
            GameManager.instance.clearedAll = false;
            GameManager.instance.hud.updatePower();
            GameManager.instance.playerLives -= 1;
            GameManager.instance.playerBombs = 2;
            GameManager.instance.hud.updateBombs();
            StartCoroutine(missStop());
            return;
        }
    }

    private void Graze()
    {
        GameManager.instance.graze++;
        GameManager.instance.hud.updateGraze();
        GameManager.instance.score+=2000;
        GameManager.instance.hud.updateScore();
    }

    private void missPowerLoss()
    {
        if(GameManager.instance.playerPower - 0.5f < 0)
        {
            GameManager.instance.playerPower = 0f;
            return;
        }
        GameManager.instance.playerPower -= 0.5f;
    }

    private void missPowerDrops()
    {
        if(GameManager.instance.playerLives == 1)
        {
            Instantiate(missDropsPrefabs[2], new Vector3(transform.position.x,transform.position.y+0.7f,transform.position.z),Quaternion.identity);
            return;
        }
        Instantiate(missDropsPrefabs[0], new Vector3(transform.position.x+0.6f,transform.position.y+0.3f,transform.position.z),Quaternion.identity);
        Instantiate(missDropsPrefabs[0], new Vector3(transform.position.x+0.4f,transform.position.y+0.5f,transform.position.z),Quaternion.identity);
        Instantiate(missDropsPrefabs[1], new Vector3(transform.position.x,transform.position.y+0.7f,transform.position.z),Quaternion.identity);
        Instantiate(missDropsPrefabs[0], new Vector3(transform.position.x-0.4f,transform.position.y+0.5f,transform.position.z),Quaternion.identity);
        Instantiate(missDropsPrefabs[0], new Vector3(transform.position.x-0.6f,transform.position.y+0.3f,transform.position.z),Quaternion.identity);
    }

    private IEnumerator missStop()
    {
        GetComponent<Animator>().SetBool("miss", true);
        pm.setSpeed(0f);
        yield return new WaitForSeconds(0.5f);
        if(pm.getFocus())
        {
            pm.setSpeed(pm.getSpeed()/2);
        } else {
            pm.setSpeed(pm.getSpeed());
        }
        GetComponent<Animator>().SetBool("miss", false);
    }

    public void setLastImmune(float value)
    {
        lastImmune = value;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
