using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{


    private Animator animator;
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public Transform attatckPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetweenAttack <= 0)
        {
            //then you can attack

            if (Input.GetKey(KeyCode.E)) 
            {
                animator.SetBool("IsAttacking",true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attatckPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().Health -= damage;//Lav TakeDamage i Enemy sript
                }


                timeBetweenAttack = startTimeBetweenAttack;
            }     
        }
        else
        {
            animator.SetBool("IsAttacking", false);
            timeBetweenAttack -= Time.deltaTime;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attatckPos.position, attackRange);
    }
}
