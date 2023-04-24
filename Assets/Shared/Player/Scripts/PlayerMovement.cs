using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Animator ani;
    private float angle = 0f;
    private Vector2 moveDir;
    private Rigidbody2D rb;
    private bool focus;
    private PlayerAttack pa;

    [SerializeField] private float speed;
    private float originalSpeed;

    [SerializeField] private GameObject focusHitbox;
    
    [SerializeField] private InputAction controls;
    [SerializeField] private InputAction slowDown;

    private void Start()
    {
        originalSpeed = this.speed;
        controls.Enable();
        slowDown.Enable();
        slowDown.performed += focusOn;
        slowDown.canceled += focusOff;
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        pa = GetComponent<PlayerAttack>();
    }
    
    private void Update()
    {
        moveDir = controls.ReadValue<Vector2>();
        if (focusHitbox.activeSelf)
        {
            focusHitbox.transform.rotation = Quaternion.Euler(0f,0f,angle);
            angle += 0.1f;
        }
    }

    private void FixedUpdate()
    {
        if (moveDir.x > 0)
        {
            ani.SetBool("moveRight", true);
            ani.SetBool("moveLeft", false);
        } else if (moveDir.x < 0) {
            ani.SetBool("moveLeft", true);
            ani.SetBool("moveRight", false);
        } else if (moveDir.x == 0){
            ani.SetBool("moveRight", false);
            ani.SetBool("moveLeft", false);
        }
        
        rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
    }

    private void focusOn(InputAction.CallbackContext context)
    {
        focus = true;
        focusHitbox.SetActive(true);
        if(!pa.getBombed())
        {
            speed = (speed/(8/3));
        }
    }

    private void focusOff(InputAction.CallbackContext context)
    {
        focus = false;
        focusHitbox.SetActive(false);
        if(!pa.getBombed())
        {
            speed = (speed*(8/3));
        }
    }

    public bool getFocus()
    {
        return this.focus;
    }

    public float getSpeed()
    {
        return this.originalSpeed;
    }

    public void setSpeed(float value)
    {
        this.speed = value;
    }
}
