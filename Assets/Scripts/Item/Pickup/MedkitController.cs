using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitController : MonoBehaviour
{
    GameObject player;
    PlayerBehavior playerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Aceknight");
        playerScript = player.GetComponent<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerScript.Heal(50);
            Destroy(gameObject);
        }
    }
}
