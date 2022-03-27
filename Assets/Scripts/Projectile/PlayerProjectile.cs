using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : ProjectileBehavior
{
    public float Damage { get; set; }
    public bool Silenced;
    // Start is called before the first frame update
    void Start()
    {
        LifeTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        LifeTimer += Time.deltaTime;
        if (LifeTimer > 10f)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11 || collision.gameObject.layer == 14)
        {
            EnemyHealth enemyHP = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHP.decreaseHealth(Damage);
        }
        //if (collision.gameObject.layer == 6)
        Destroy(gameObject);
    }
}
