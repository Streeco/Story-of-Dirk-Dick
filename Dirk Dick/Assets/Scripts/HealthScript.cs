using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    private int health = 100;
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health <= 0)
            {
                // kill object, if player game over
                Destroy(gameObject);
            }
            if (gameObject.CompareTag("Player"))
            {
                GameObject.Find("healthbar").GetComponent<HealthbarScript>().UpdateHealthbarSprite();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
}