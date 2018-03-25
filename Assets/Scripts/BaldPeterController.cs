using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaldPeterController : MonoBehaviour
{

    public Transform target;

    [Range(1, 3)]
    public float speed;

    public float distToTarget;

    private Animator animator;
    private NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = speed;
        distToTarget = Vector3.Distance(transform.position, target.position);
        if (distToTarget > 2f)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
        }
        else
        {
            agent.isStopped = true;
        }
        animator.SetFloat("Forward", agent.velocity.magnitude);
    }
}
