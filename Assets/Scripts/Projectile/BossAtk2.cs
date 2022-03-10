using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtk2 : MonoBehaviour
{
    PlayerBehavior playerScript;
    float LifeTimer;
    // Start is called before the first frame update
    void Start()
    {
        
        LifeTimer = 0f;
        GameObject player = GameObject.Find("Aceknight");
        playerScript = player.GetComponent<PlayerBehavior>();
    
    }

    // Update is called once per frame
    void Update()
    {
        LifeTimer += Time.deltaTime;
        if (LifeTimer >= 0.3f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            playerScript.TakeDamage(200);
        Destroy(gameObject);
    }
}
