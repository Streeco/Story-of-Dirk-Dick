using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;

    public Transform target;
    public float chaseRange;

    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;

    public GameObject projectile;
    public float laserForce;

    // Start is called before the first frame update
    void Start()
    {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
    }

    // Update is called once per frame
    void Update()
    {
        // Attacking AI - Range
        // Check to see if the player is within our attack range
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if(distanceToPlayer < attackRange)
        {
            //turn towards the target
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);

            //check to see if its time to attack
            if (Time.time > lastAttackTime + attackDelay)
            {
                //raycast to see if we have line of sight to the target
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, attackRange);
                //check to see if we hit anything
                if(hit.transform == target)
                {
                    //hit the player - fire the projectile
                    GameObject newlaser = Instantiate(projectile, transform.position, transform.rotation);
                    newlaser.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, laserForce));
                    lastAttackTime = Time.time;
                }
            }
        }
    }
}
