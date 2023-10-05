using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    protected bool m_IsPlayerInView;
    public Transform FollowTarget;

    [SerializeField]
    private NavMeshAgent m_Agent;
    [SerializeField]
    private Animator m_Anim;
    [SerializeField]
    private AudioSource audio;

    public float JudgeReachDistance;
    public Transform[] PatrolPoints;
    public float PatrolIntervalDelay;
    private int PatrolIndex;

    public bool IsPlayerInView
    {
        get { return m_IsPlayerInView; }
        set { m_IsPlayerInView = value; }
    }

    private int Anim_IsMoving;
    private bool IsPatroling;

    private void Awake()
    {
        Anim_IsMoving = Animator.StringToHash("IsMoving");
    }

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        //playSound();
    }

    private void Update()
    {
        //UpdateAnim();
        KeepFollowingTarget();

        //Debug.Log(Vector3.Distance(transform.position, PatrolPoints[PatrolIndex].position));
    }

    private bool IsChasing;
    public void KeepFollowingTarget()
    {
        //Debug.Log(m_Agent.velocity);
        if (IsPlayerInView)
        {
            Debug.Log("Chase Player");
            StopCoroutine(PatrolCou());
            IsPatroling = false;

            if(!IsChasing)
            {
                StartCoroutine(UpdateChasePlayer());
            }

            //Debug.Log(FollowTarget.position);
        }
        else
        {

            if(!IsPatroling)
            {
                StartCoroutine(PatrolCou());
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(m_Agent.destination, 2);
    }

    private IEnumerator UpdateChasePlayer()
    {
        IsChasing = true;
        m_Agent.SetDestination(FollowTarget.position);
        yield return new WaitForSeconds(2);
        IsChasing = false;
    }

    private IEnumerator PatrolCou()
    {
        Debug.Log("Patrol");
        m_Agent.SetDestination(PatrolPoints[PatrolIndex].position);
        IsPatroling = true;
        //Debug.Log("Set Patrol Point");
        yield return new WaitUntil(() => Vector3.Distance(transform.position, PatrolPoints[PatrolIndex].position) <= JudgeReachDistance);
        yield return new WaitForSeconds(PatrolIntervalDelay);

        IsPatroling = false;
        PatrolIndex++;
        if(PatrolIndex>=PatrolPoints.Length)
        {
            PatrolIndex = 0;
        }
    }

    private void UpdateAnim()
    {
        if(IsPlayerInView || m_Agent.velocity.sqrMagnitude>0.5f)
        {
            m_Anim.SetBool(Anim_IsMoving, true);
        }
        else
        {
            m_Anim.SetBool(Anim_IsMoving, false);
        }
    }

    private void playSound()
    {
        audio.loop = true;
        audio.Play();
    }
}
