using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior1 : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    private Transform playerRef;
    private Vector2 target;

    [SerializeField]
    Collider2D bulletCollider;
    [SerializeField]
    public LayerMask groundLayer;
    [SerializeField]
    float damage;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2 (playerRef.position.x, playerRef.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool a = collision.CompareTag("Player");
        bool b = bulletCollider.IsTouchingLayers(groundLayer);
        if (collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().TakeDamage(damage);
            DestroyProjectile();

        }
        if (collision.gameObject.CompareTag("Ground") )
        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
