using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarScript : MonoBehaviour
{
    public Camera camera;
    public GameObject player;
    public Sprite noDamageSprite;
    public Sprite minorDamageSprite;
    public Sprite mediumDamageSprite;
    public Sprite heavyDamageSprite;
    Vector3 offset;
    int maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = player.GetComponent<HealthScript>().Health;
        offset = transform.position - camera.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = camera.transform.position + offset;
    }

    public void UpdateHealthbarSprite()
    {
        int health = player.GetComponent<HealthScript>().Health;

        if (health > maxHealth * 0.75)
        {
            GetComponent<SpriteRenderer>().sprite = noDamageSprite;
        }
        else if (health > maxHealth * 0.5)
        {
            GetComponent<SpriteRenderer>().sprite = minorDamageSprite;
        }
        else if (health > maxHealth * 0.25)
        {
            GetComponent<SpriteRenderer>().sprite = mediumDamageSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = heavyDamageSprite;
        }
    }
}
