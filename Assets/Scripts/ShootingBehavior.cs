using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehavior : MonoBehaviour
{
    private float tbs;

    [SerializeField]
    GameObject projectile;
    [SerializeField]
    public float startTBS; 

    // Start is called before the first frame update
    void Start()
    {
        tbs = startTBS;
    }

    // Update is called once per frame
    void Update()
    {
        if(tbs <= 0)
        {
            Instantiate(projectile, transform.position,Quaternion.identity);
            tbs = startTBS;
        }
        else
        {
            tbs -= Time.deltaTime;
        }
    }
}
