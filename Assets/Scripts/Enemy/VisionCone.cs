using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    [SerializeField] public float radius;
    [SerializeField][Range(1f, 360f)] float viewAngle;
    [SerializeField][Range(0f, 360f)] public float rootAngle;
    [SerializeField] LayerMask targetLayer;
    [SerializeField] LayerMask obstruction;
    [SerializeField] float refreshingTime;
    private Vector2 rootSight;
    public bool CanSeePlayer { get; private set; }

    public GameObject playerRef;

    // Start is called before the first frame update
    void Start()
    {
        rootSight = getRootSight();
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCheck());
    }

    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(refreshingTime);

        while (true)
        {
            yield return wait;
            FOV();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rootSight = getRootSight();
    }

    private void FOV()
    {
        Collider2D rangeCheck = Physics2D.OverlapCircle(transform.position, radius,targetLayer);

        if (rangeCheck != null)
        {
            Transform target = rangeCheck.transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;
            if(Vector2.Angle(rootSight,directionToTarget) < viewAngle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position,target.position);
                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstruction))
                {
                    CanSeePlayer = true;
                }
                else CanSeePlayer = false;
            }
            else CanSeePlayer = false ;
        } 
        else CanSeePlayer = false ;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 line = new Vector3(rootSight.x,rootSight.y, transform.position.z);
        Gizmos.DrawLine(transform.position, transform.position + line * radius );

        if (CanSeePlayer)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position,playerRef.transform.position);
        }
    }

    private Vector2 getRootSight()
    {
        return new Vector2(Mathf.Cos(rootAngle * Mathf.Deg2Rad), Mathf.Sin(rootAngle * Mathf.Deg2Rad));
    }
}
