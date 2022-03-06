using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private BoxCollider2D groundCheck;
    [SerializeField] private BoxCollider2D wallCheck;
    [SerializeField] private Collider2D footCollider;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] private bool _beginDirection;
    [SerializeField] public bool mustPatrol;
    [SerializeField] VisionCone vision;
    private int _directionMulti;
    Rigidbody2D enemyBody;

    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        if (_beginDirection)
        {
            _directionMulti = 1;
        }
        else
        {
            _directionMulti = -1;
            transform.localScale = new Vector2(_directionMulti, transform.localScale.y);
        }
        vision = GetComponent<VisionCone>();
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            bool isFeetOnGround = footCollider.IsTouchingLayers(groundLayer);
            bool isNeedFlip = !groundCheck.IsTouchingLayers(groundLayer) || wallCheck.IsTouchingLayers(groundLayer);
            if (isFeetOnGround && isNeedFlip)
            {
                Flip();
            }
            MoveForward();
        }
    }

    private void Flip()
    {
        _directionMulti *= -1;
        transform.localScale = new Vector2(_directionMulti*transform.localScale.x, transform.localScale.y);
        if(vision != null)
        {
            vision.rootAngle = 360 - vision.rootAngle;
        }
    }

    private void MoveForward()
    {
        enemyBody.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime * _directionMulti, enemyBody.velocity.y);
    }

    
}
