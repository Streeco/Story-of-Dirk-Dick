using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingRobotAI : MonoBehaviour
{
    public float speed = 50;

    bool aggroed = false;
    public bool attacking = false;
    GameObject player;
    Rigidbody2D rb;
    bool isRight = false;
    Animator animator;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If not attacking and player gets near, attack
        if (aggroed == false && Vector3.Distance(player.transform.position, transform.position) < 300)
        {
            aggroed = true;
        }

        if (aggroed == true)
        {
            direction = player.transform.position - transform.position;
            direction = direction.normalized;

            if (direction.x < 0 && isRight) Flip();
            if (direction.x > 0 && !isRight) Flip();

            AnimationHandling();

            // if not attacking, move
            if (attacking == false) rb.velocity = new Vector2(direction.x * speed * Time.deltaTime * 10, rb.velocity.y);
            
        }
    }

    void Flip()
    {
        isRight = !isRight;
        transform.Rotate(Vector3.up * 180);
    }

    void AnimationHandling()
    {
        // Set walking animation
        if (direction.x != 0)
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        // Set attack animation
        if (Vector2.Distance(player.transform.position, transform.position) < 4)
        {
            attacking = true;
            animator.SetInteger("Attack", Random.Range(1, 4));
        }
        else
        {
            attacking = false;
            animator.SetInteger("Attack", 0);
        }

    }
}
