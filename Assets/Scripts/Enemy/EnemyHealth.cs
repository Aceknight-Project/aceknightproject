using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;

 

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void decreaseHealth(float damage) 
    {
        health -= damage;
    }
}
