using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flak : ProjectileBehavior
{
    public float Damage;
    GameObject bossScript;
    void Start()
    {
        Damage = 20000f;
        Speed = 1000f;
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
        //if (collision.gameObject.layer == 6)
            Destroy(gameObject);
    }
}
