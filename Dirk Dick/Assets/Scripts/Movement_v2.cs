using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_v2 : MonoBehaviour
{
    public int speed = 50;
    public bool isRight = true;

    Rigidbody2D rb;
    Animator animator;
    
    //Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(movementHorizontal, 0).normalized * speed * Time.deltaTime * 10;


        if (movementHorizontal != 0)
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        if (Input.GetAxis("Horizontal") < 0 && isRight) Flip();
        if (Input.GetAxis("Horizontal") > 0 && !isRight) Flip();

        rb.velocity = new Vector2(moveVelocity.x, rb.velocity.y);

    }
    void FixedUpdate()
    {

    }

    void Flip()
    {
        isRight = !isRight;
        transform.Rotate(Vector3.up * 180);
    }
}
