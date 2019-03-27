using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    
    public float speed;
    private Vector2 moveVelocity;
    private Rigidbody2D rb;
    public bool isRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;



        if (Input.GetAxis("Horizontal") < 0 && isRight) Flip();
        if (Input.GetAxis("Horizontal") > 0 && !isRight) Flip();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        
    }

    void Flip()
    {
        isRight = !isRight;
        transform.Rotate(Vector3.up * 180);
    }
}

