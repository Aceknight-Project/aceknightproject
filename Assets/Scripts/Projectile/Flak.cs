using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flak : ProjectileBehavior
{
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
        //if (collision.gameObject.tag == "Boss")
            //playerScript.TakeDamage(5000);
        Destroy(gameObject);
    }
}
