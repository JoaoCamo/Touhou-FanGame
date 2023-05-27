using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossMovement : MonoBehaviour
{
    private float xSpeed = 0;
    private float ySpeed = 0;

    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(moveDown());
    }

    private void Update()
    {
        rb.velocity = new Vector2(this.xSpeed, this.ySpeed);

        if (transform.position.x >= 0.5f) transform.position = new Vector2(0.5f, transform.position.y);
        if (transform.position.x <= -2f) transform.position = new Vector2(-2f, transform.position.y);
        if (transform.position.y >= 1.4f) transform.position = new Vector2(transform.position.x, 1.4f);
        if (transform.position.y <= 0.4f) transform.position = new Vector2(transform.position.x, 0.4f);;
    }

    private IEnumerator startMovement()
    {
        yield return new WaitForSeconds(2.75f);
        
        int type = Random.Range(0, 4);

        if(type == 0) StartCoroutine(moveUp());
        else if(type == 1) StartCoroutine(moveDown());
        else if(type == 2) StartCoroutine(moveRight());
        else if(type == 3) StartCoroutine(moveLeft());
        
        type = Random.Range(0, 5);

        if(type == 1) StartCoroutine(moveUp());
        else if(type == 2) StartCoroutine(moveDown());
        else if(type == 3) StartCoroutine(moveRight());
        else if(type == 4) StartCoroutine(moveLeft());
    }

    private IEnumerator moveLeft()
    {
        this.xSpeed = -0.75f;
        yield return new WaitForSeconds(0.5f);
        this.xSpeed = 0f;
        StartCoroutine(startMovement());
    }
    
    private IEnumerator moveRight()
    {
        this.xSpeed = 0.75f;
        yield return new WaitForSeconds(0.5f);
        this.xSpeed = 0f;
        StartCoroutine(startMovement());
    }
    
    private IEnumerator moveUp()
    {
        this.ySpeed = 0.75f;
        yield return new WaitForSeconds(0.5f);
        this.ySpeed = 0f;
        StartCoroutine(startMovement());
    }
    
    private IEnumerator moveDown()
    {
        this.ySpeed = -0.75f;
        yield return new WaitForSeconds(0.5f);
        this.ySpeed = 0f;
        StartCoroutine(startMovement());
    }
}
