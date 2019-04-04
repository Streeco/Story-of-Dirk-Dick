﻿using UnityEngine;

public class Player_Movement_Stok : MonoBehaviour
{
    Animator animator;
    public float speed;
    private Vector2 moveVelocity;
    private Vector2 moveVelocity2;
    private Rigidbody2D rb;
    public bool isRight;
    public bool stok;
    


    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 moveInput2 = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
        moveVelocity = moveInput.normalized * speed;
        moveVelocity2 = moveInput2.normalized * speed;


        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.UpArrow
            ) || (Input.GetKey(KeyCode.DownArrow)))))))) 
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


        if (Input.GetAxis("Horizontal") < 0 && isRight || Input.GetAxis("Horizontal2") < 0 && isRight) Flip();
        if (Input.GetAxis("Horizontal") > 0 && !isRight || Input.GetAxis("Horizontal2") > 0 && !isRight) Flip();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + moveVelocity2 * Time.fixedDeltaTime);

    }

    void Flip()
    {
        isRight = !isRight;
        transform.Rotate(Vector3.up * 180);
    }
}

