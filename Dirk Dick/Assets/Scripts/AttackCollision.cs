using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
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
            player.GetComponent<HealthScript>().Health -= GetComponentInParent<BoxingRobotAI>().damage;
        }
    }
}
