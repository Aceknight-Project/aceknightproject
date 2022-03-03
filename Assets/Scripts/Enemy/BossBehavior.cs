using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
 
    [SerializeField]
    GameObject bullet;
    float time = 0f;
  
    
    // Start is called before the first frame update
    void Start()
    {
      
       
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3)
        {
            GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
            time = 0f;
        }
      

    }


}
