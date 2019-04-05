using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int health = 10;
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health <= 0)
            {
                GetComponent<Animator>().SetBool("Dead", true);
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
