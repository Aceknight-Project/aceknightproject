using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : PatrolBehavior
{
    [SerializeField] float shootingCooldown;
    [SerializeField] GameObject Suicider;

    private VisionCone vision;
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0;
        vision = GetComponent<VisionCone>();
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
        float targetx = GameObject.Find("Aceknight").transform.position.x - transform.position.x;
        GameObject suicider = Instantiate(Suicider, transform.position, Quaternion.identity);
        if (targetx < 0)
            suicider.GetComponent<SuicideBehavior>()._beginDirection = false;
        FindObjectOfType<AudioManager>().Play("Lightning");
    }

    void ChangePatrolBehavior(bool isPatrol)
    {
        mustPatrol = isPatrol;
    }
}
