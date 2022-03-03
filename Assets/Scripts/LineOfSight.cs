using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    [SerializeField]
    float radius;
    [SerializeField]
    [Range(1, 360)]
    float angle;
    [SerializeField]
    [Range(0, 360)]
    float rootLineSight;
    [SerializeField]
    LayerMask targetLayer;
    [SerializeField]
    LayerMask obstructionLayer;
    [SerializeField]
    GameObject playerRef;
    public bool CanSeePlayer { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVCheck());
    }

    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            FOV();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FOV()
    {
        Collider2D rangeCheck = Physics2D.OverlapCircle(transform.position,radius,targetLayer);

        if(rangeCheck != null)
        {
            Transform target = rangeCheck.transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;
            if(Vector2.Angle(getRootSight(), directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if(Physics2D.Raycast(transform.position, directionToTarget,distanceToTarget, obstructionLayer))
                {
                    CanSeePlayer = true;
                }
                else
                {
                    CanSeePlayer = false;
                }
            }
            else
            {
                CanSeePlayer=false;
            }
        }
    }

    private Vector2 getRootSight()
    {
        return new Vector2(Mathf.Sin(rootLineSight * Mathf.Deg2Rad), Mathf.Cos(rootLineSight * Mathf.Deg2Rad));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, radius);

        Vector3 angle1 = DirectionFromAngle(rootLineSight, -angle/2);
        Vector3 angle2 = DirectionFromAngle(rootLineSight, angle / 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle1 * radius);
        Gizmos.DrawLine(transform.position, transform.position + angle2 * radius);
        Gizmos.DrawLine(transform.position, transform.position + (Vector3) getRootSight() * radius);
        if (CanSeePlayer)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, playerRef.transform.position);
        }


    }

    private Vector2 DirectionFromAngle(float euler, float angleInDegree)
    {
        angleInDegree += euler;
        return new Vector2(Mathf.Sin(angleInDegree * Mathf.Deg2Rad), Mathf.Cos(angleInDegree * Mathf.Deg2Rad));
    }
}
