using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<BoxingRobotAI>().hand.enabled = false;
            GetComponentInParent<BoxingRobotAI>().enemyRecievedDamage = true;
            GameObject.Find("McDinglenuts").transform.position += new Vector3(0, 1);
        }
    }
}
