﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingRobotAI : MonoBehaviour
{
    public float speed = 25;
    [HideInInspector]
    public CircleCollider2D hand;
    [HideInInspector]
    public bool attacking = false;
    [HideInInspector]
    public bool enemyRecievedDamage = true;
    public int damage = 5;
    public int aggroRange = 10;

    bool aggroed = false;
    GameObject player;
    Rigidbody2D rb;
    Animator animator;
    Vector2 direction;
    bool isRight = false;
    bool damageDealt = true;
    int attackAnimation;



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
        if (enemyRecievedDamage != true)
        {
            hand.enabled = false;
        }
        // If not attacking and player gets near, attack
        if (aggroed == false && Vector3.Distance(player.transform.position, transform.position) < aggroRange)
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
            if (attacking == false && animator.GetCurrentAnimatorStateInfo(0).IsName("RoboWalk") == true)
            {
                rb.velocity = new Vector2(direction.x * speed * Time.deltaTime * 10, rb.velocity.y);
            }
        }

        // delete if boxingrobot get death animation
        if (animator.GetBool("Dead") == true)
        {
            Kill();
        }
    }

    void Flip()
    {
        //if (/*isRight == false*/true)
        //{
            //transform.Find("Attack1").transform.localPosition = new Vector3(3.22f, 1);
            //transform.Find("Attack2").transform.localPosition = new Vector3(4.56f, 0);
            //transform.Find("Attack3").transform.localPosition = new Vector3(6.98f, 0);
        //}
        //else
        //{
        //    transform.Find("Attack1").transform.localPosition = new Vector3(3.22f, 1);
        //    transform.Find("Attack2").transform.localPosition -= new Vector3(4.56f, 0);
        //    transform.Find("Attack3").transform.localPosition -= new Vector3(6.98f, 0);
        //}

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
        if (damageDealt == true && Vector2.Distance(player.transform.position, transform.position) < 4)
        {
            attacking = true;
            attackAnimation = Random.Range(1, 4);
            animator.SetInteger("Attack", attackAnimation);
            damageDealt = false;
        }
        else
        {
            attacking = false;
            animator.SetInteger("Attack", 0);
            damageDealt = true;
        }
    }

    void DealDamage()
    {
        rb.velocity = Vector2.zero;
        switch (attackAnimation)
        {
            case 1:
                hand = transform.Find("Attack1").GetComponent<CircleCollider2D>();
                break;
            case 2:
                hand = transform.Find("Attack2").GetComponent<CircleCollider2D>();
                break;
            case 3:
                hand = transform.Find("Attack3").GetComponent<CircleCollider2D>();
                break;
            default:
                hand = transform.Find("Attack1").GetComponent<CircleCollider2D>();
                break;
        }

        hand.enabled = true;
        //if (Physics2D.IsTouching(hand, player.GetComponent<CapsuleCollider2D>()))
        //{
        //    player.transform.position = new Vector3(100, 100);
        //}

        //hand.enabled = false;
        damageDealt = true;
    }

    void DisableDamageDealing()
    {
        hand.enabled = false;
    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
