using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    [SerializeField]
    bool facing;
    [SerializeField] private float moveSpeed;
    [SerializeField] private BoxCollider2D groundCheck;
    [SerializeField] private BoxCollider2D wallCheck;
    [SerializeField] private Collider2D footCollider;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] public bool _beginDirection;
    [SerializeField] public bool mustPatrol;
    [SerializeField] VisionCone vision;
    private float _directionMulti;
    Rigidbody2D enemyBody;

    // Start is called before the first frame update
    void Start()
    {
        if (facing)
            Flip();
        enemyBody = GetComponent<Rigidbody2D>();
        if (_beginDirection)
        {
            _directionMulti = 0.5f;
        }
        else
        {
            _directionMulti = -0.5f;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "FriendlyProjectile")
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = footCollider.bounds.center;

            bool right = contactPoint.x > center.x;

            if (right)
            {
                if (_directionMulti < 0) 
                    Flip();
            }
            else
            {
                if (_directionMulti > 0)
                {
                    Flip();
                }
            }
            Destroy(collision.collider.gameObject);
        }
    }
    private void Flip()
    {
        _directionMulti *= -1;
        transform.localScale = new Vector2(_directionMulti, transform.localScale.y);
        if (vision != null)
        {
            if (_directionMulti > 0)
            {
                if (vision.rootAngle >= 270 && vision.rootAngle <= 90) vision.rootAngle = 360 - vision.rootAngle;
                if (vision.rootAngle == 180) vision.rootAngle = 0;
            }
            else
            {
                if (vision.rootAngle > 90 && vision.rootAngle < 270) vision.rootAngle = 360 - vision.rootAngle;
                if (vision.rootAngle == 0) vision.rootAngle = 180;
            }


        }
    }

    private void MoveForward()
    {
        enemyBody.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime * _directionMulti, enemyBody.velocity.y);
    }

}
