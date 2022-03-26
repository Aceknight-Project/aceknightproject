using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    float health;
    [SerializeField]
    GameObject DeathAnimation;
 

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Instantiate(DeathAnimation, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Death");
            Destroy(gameObject);
        }
    }

    public void decreaseHealth(float damage) 
    {
        health -= damage;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
