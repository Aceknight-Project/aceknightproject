using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D col;
    [SerializeField] LayerMask ground;
    public float damage = 20;

    public GameObject playerRef;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = gameObject.transform.parent.position;
        playerRef = GameObject.FindGameObjectWithTag("Player");
        if(playerRef != null)
        {
            Vector2 direction = (playerRef.transform.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = transform.right * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DealDamage()
    {
        if(playerRef != null)
        {
            playerRef.GetComponent<PlayerBehavior>().TakeDamage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (col.IsTouchingLayers(ground))
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                DealDamage();
            }

            Destroy(gameObject);
        }
    }
}
