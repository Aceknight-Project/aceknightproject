using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    float speed =10f;
    [SerializeField]
    GameObject player;

     void Start()
    {
        float step = speed * Time.deltaTime;
       // GameObject player = GameObject.Find("Aceknight");

        GetComponent<Rigidbody2D>().AddForce( speed * (player.transform.position - transform.position));

    }

    // Update is called once per frame
    void Update()
    {
          
       
    }
}
