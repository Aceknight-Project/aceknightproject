using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehavior : MonoBehaviour
{
    [SerializeField] float shootingCooldown;
    [SerializeField] float damage;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPoint;

    private VisionCone vision;
    private PatrolBehavior patrolBehavior;
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0;
        vision = GetComponent<VisionCone>();
        patrolBehavior = GetComponent<PatrolBehavior>();
        bullet.GetComponent<NormalBullet>().damage = damage;
    }

    private void FixedUpdate()
    {
        if (vision.CanSeePlayer)
        {
            ChangePatrolBehavior(false);
            if (cooldown <= 0)
            {
                Shoot();
                cooldown = shootingCooldown; 
            }
        }
        else
        {
            ChangePatrolBehavior(true);
        }
        cooldown -= Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Shoot()
    {
        Instantiate(bullet, bulletPoint,false);
    }

    void ChangePatrolBehavior(bool isPatrol)
    {
        if(patrolBehavior != null)
        {
            patrolBehavior.mustPatrol = isPatrol;
        }
    }
}
