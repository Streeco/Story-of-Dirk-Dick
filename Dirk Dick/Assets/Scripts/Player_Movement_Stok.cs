﻿using UnityEngine;

public class Player_Movement_Stok : MonoBehaviour
{
    Animator animator;
    public float speed;
    private Vector2 moveVelocity;
    private Rigidbody2D rb;
    public bool isRight;
    public bool stok;
    public GameObject obt;


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
        moveVelocity = moveInput.normalized * speed;
        


        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.S))))) 
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }




        if (stok == true)
        {
            animator.SetBool("Stok", true);
        }



        if (Input.GetAxis("Horizontal2") < 0 && isRight) Flip();
        if (Input.GetAxis("Horizontal2") > 0 && !isRight) Flip();
        //rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        rb.position += (moveVelocity * Time.deltaTime);
    }

    //void FixedUpdate()
    //{
        
    //}

    void Flip()
    {
        isRight = !isRight;
        transform.Rotate(Vector3.up * 180);
    }
}

