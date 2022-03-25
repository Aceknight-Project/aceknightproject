using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtk1 : ProjectileBehavior
{
    PlayerBehavior playerScript;
    // Start is called before the first frame update
    void Start()
    {
        Speed = 1000f;
        LifeTimer = 0f;
        GameObject player = GameObject.Find("Aceknight");
        playerScript = player.GetComponent<PlayerBehavior>();
        GetComponent<Rigidbody2D>().AddForce(Speed * (player.transform.position - transform.position).normalized);
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
        if (collision.gameObject.tag == "Player")
            playerScript.TakeDamage(20);
        Destroy(gameObject);
    }
}
