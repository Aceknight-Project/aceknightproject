using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;
    public bool mustFlip;
    public Rigidbody2D body;
    public float movingSpeed;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        };
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustFlip || bodyCollider.IsTouchingLayers(groundLayer)) Flip();
        body.velocity = new Vector2(movingSpeed * Time.deltaTime, body.velocity.y);
    }
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        movingSpeed *= -1;
        mustPatrol = true;
    }
}
