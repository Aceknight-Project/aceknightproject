using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject bossArea;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x , player.transform.position.y, -10);
    }
}
