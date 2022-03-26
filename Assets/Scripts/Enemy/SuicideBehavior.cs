using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideBehavior : PatrolBehavior
{
    [SerializeField]
    GameObject explosion;
    GameObject player;
    PlayerBehavior playerBehavior;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Aceknight")
        {
            player = GameObject.Find("Aceknight");
            playerBehavior = player.GetComponent<PlayerBehavior>();
            playerBehavior.TakeDamage(30);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void setFace(bool facing)
    {
        _beginDirection = facing;
    }
}
