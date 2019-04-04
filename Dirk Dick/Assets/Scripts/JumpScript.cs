using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    Rigidbody2D rigidbody;
    float distanceToCheck;
    bool onGround;

    public float jumpforce = 7;
    public KeyCode key = KeyCode.Space;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(key) && onGround)
        {
            rigidbody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            onGround = false;

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            onGround = true;

        }
    }
}
