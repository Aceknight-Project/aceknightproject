using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flak : ProjectileBehavior
{
    public float Damage = 5000f;
    GameObject bossScript;
    void Start()
    {
        Speed = 10f;
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
