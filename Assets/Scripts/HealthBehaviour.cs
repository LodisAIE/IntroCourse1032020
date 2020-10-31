using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    [SerializeField]
    //Stores the health
    private float health = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage(float damageAmount)
    {
        health = health - damageAmount;
        //Checks to see if the game object is still alive
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //Increases the game objects health by the given value
    public float Heal(float healVal)
    {
        health = health + healVal;
        return health;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
