using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private bool LTR;
    [SerializeField] private bool RTL;
    [SerializeField] private bool TL;
    [SerializeField] private bool TR;
    [SerializeField] private float xSpeed;
    [SerializeField] private float ySpeed;

    public void setMovement(bool ltr=false,bool rtl=false,bool tl=false,bool tr=false)
    {
        this.LTR = ltr;
        this.RTL = rtl;
        this.TL = tl;
        this.TR = tr;
    }

    private void Start()
    {
        movementBehaviour();
    }

    private void FixedUpdate()
    {
        transform.Translate(this.xSpeed*Time.deltaTime,this.ySpeed*Time.deltaTime,0);
    }

    private void movementBehaviour()
    {
        if(LTR) StartCoroutine(leftToRight());
        else if(RTL) StartCoroutine(rightToLeft());
        else if(TL) StartCoroutine(topLeft());
        else if(TR) StartCoroutine(topRight());
    }

    private IEnumerator leftToRight()
    {
        this.xSpeed = -1f;
        yield return new WaitForSeconds(0.9f);
        this.xSpeed = -0.15f;
        yield return new WaitForSeconds(0.65f);
        this.xSpeed = -0.4f;
    }

    private IEnumerator rightToLeft()
    {
        this.xSpeed = 1f;
        yield return new WaitForSeconds(0.9f);
        this.xSpeed = 0.15f;
        yield return new WaitForSeconds(0.65f);
        this.xSpeed = 0.4f;
    }

    private IEnumerator topLeft()
    {
        this.ySpeed = -1f;
        yield return new WaitForSeconds(0.9f);
        this.ySpeed = 0f;
        yield return new WaitForSeconds(5f);
        this.xSpeed = -0.4f;
    }

    private IEnumerator topRight()
    {
        this.ySpeed = -1f;
        yield return new WaitForSeconds(0.9f);
        this.ySpeed = 0f;
        yield return new WaitForSeconds(5f);
        this.xSpeed = 0.4f;
    }
}
