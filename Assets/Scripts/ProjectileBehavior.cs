using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    float speed =10f;
    PlayerBehavior playerScript;
    void Start()
    {
        float step = speed * Time.deltaTime;
        GameObject player = GameObject.Find("Aceknight");
        playerScript = player.GetComponent<PlayerBehavior>();
        GetComponent<Rigidbody2D>().AddForce( speed * (player.transform.position - transform.position));

    }

    // Update is called once per frame
    void Update()
    {
          
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerScript.TakeDamage(20);
            Destroy(gameObject);
        }
    }
}
