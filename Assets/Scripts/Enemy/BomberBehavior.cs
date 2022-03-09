using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberBehavior : MonoBehaviour
{
    [SerializeField] float throwCooldown;
    [SerializeField] float damage;
    [SerializeField] GameObject bomb;
    [SerializeField] Transform bombPoint;

    private VisionCone vision;
    private PatrolBehavior patrolBehavior;
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0;
        vision = GetComponent<VisionCone>();
        bomb.GetComponent<BombBehavior>().damage = damage;
    }

    private void FixedUpdate()
    {
   
            if (cooldown <= 0)
            {
                Thrown();
                cooldown = throwCooldown;
            }

        cooldown -= Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Thrown()
    {
        Instantiate(bomb, bombPoint, false);
    }

}
