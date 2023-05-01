using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    // Start is called before the first frame update
    //
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public Vector2 v = Vector2.zero;

    void Start()
    {
        StartCoroutine("FindTargetsWithDelay", .05);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }

    void FindVisibleTargets()
    {
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);

        for(int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector2 dirToTarget = (target.position - transform.position).normalized;
            if(Vector2.Angle(v, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector2.Distance(transform.position, target.position);
                if(!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    Debug.Log("FUCK YOU");
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if(!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }
}
