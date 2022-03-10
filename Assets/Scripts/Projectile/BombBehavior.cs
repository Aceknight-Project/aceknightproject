using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    public float speed;
    [SerializeField]
    public float launchHeight = 2;
    [SerializeField]
    public float splashRange = 2;
    [SerializeField]
    public float damage = 40;
    [SerializeField]
    public float force = 5;
    [SerializeField]
    public Collider2D bombCollider;
    [SerializeField]
     LayerMask groundLayer;
    [SerializeField]
     LayerMask playerLayer;

    public Vector3 movePosition;

    private float playerX;
    private float targetX;
    private float nextX;
    private float dist;
    private float baseY;
    private float height;

    private Vector3 basePosition;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = gameObject.transform.parent.position;
        player = GameObject.FindGameObjectWithTag("Player");
        basePosition = transform.position;
        playerX = player.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        targetX = basePosition.x;
        dist = targetX - playerX;
        nextX = Mathf.MoveTowards(transform.position.x, playerX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(basePosition.y, player.transform.position.y, (nextX - targetX) / dist);
        height = launchHeight * (nextX - targetX) * (nextX - playerX) / (-0.25f * dist * dist);

        movePosition = new Vector3(nextX, baseY + height, transform.position.z);

        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;

        if(transform.position.x == targetX)
        {
            explode();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || bombCollider.IsTouchingLayers(groundLayer))
        {
            //animator.Play("explosion");
            explode();
            Destroy(gameObject);
        }
    }

    public static Quaternion LookAtTarget(Vector2 r)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, splashRange);
    }

    public void explode()
    {
        Collider2D playerRef = Physics2D.OverlapCircle(transform.position, splashRange,playerLayer);
        if(playerRef != null)
        {
            Vector2 direction = playerRef.transform.position - transform.position;
            playerRef.GetComponent<PlayerBehavior>().TakeDamage(damage);
            playerRef.GetComponent<Rigidbody>().AddForce(direction);
        }
    }
}
