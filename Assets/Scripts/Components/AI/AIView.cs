using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIView : ITrigger
{
    public EnemyAI AIComp;
    public Transform PlayerDetectPoint;
    public LayerMask DetectPointLayer;

    private bool IsPlayerInView;

    protected override void OnPlayerEnterTrigger()
    {
        base.OnPlayerEnterTrigger();

        Debug.Log("Player Enter View");

        IsPlayerInView = true;
        AIComp.FollowTarget = PlayerTrans;

    }

    protected override void OnPlayerExitTrigger()
    {
        base.OnPlayerExitTrigger();

        Debug.Log("Player Leave View");

        IsPlayerInView = false;
        AIComp.IsPlayerInView = false;
        AIComp.FollowTarget = null;
    }

    private void Update()
    {
        DetectPoint();
    }

    private void DetectPoint()
    {
        if(IsPlayerInView)
        {
            if(Physics.Raycast(transform.position,PlayerDetectPoint.position-transform.position,out RaycastHit hit,float.MaxValue,DetectPointLayer,QueryTriggerInteraction.Ignore))
            {
                //Debug.Log(hit.transform.name);
                if (hit.transform == PlayerDetectPoint)
                {
                    AIComp.IsPlayerInView = true;
                }
                else
                {
                    AIComp.IsPlayerInView = false;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, PlayerDetectPoint.position);
    }
}
