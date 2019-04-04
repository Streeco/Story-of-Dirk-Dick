using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRobotAI : MonoBehaviour
{
    public float speed = 25;
    public int damage = 5;
    public int aggroRange = 10;

    GameObject player;
    Rigidbody2D rb;
    Animator animator;
    Vector2 direction;
    bool isRight = false;
    bool aggroed = false;
    [HideInInspector]
    public bool attacking = false;
    [HideInInspector]
    public CircleCollider2D hand;
    [HideInInspector]
    public bool enemyRecievedDamage = true;
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
            if (attacking == false /*&& animator.GetCurrentAnimatorStateInfo(0).IsName("SpeedRobotwalk") == true*/)
            {
                rb.velocity = new Vector2(direction.x * speed * Time.deltaTime * 10, rb.velocity.y);
            }
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
        if (damageDealt == true && Vector2.Distance(player.transform.position, transform.position) < 5)
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
        //rb.velocity = Vector2.zero;
        hand = transform.Find("Attack").GetComponent<CircleCollider2D>();

        hand.enabled = true;
        damageDealt = true;
    }

    void DisableDamageDealing()
    {
        hand.enabled = false;
    }
}
