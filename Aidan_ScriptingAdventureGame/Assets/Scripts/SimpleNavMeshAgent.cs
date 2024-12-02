using System;
using UnityEngine;
using UnityEngine.AI;

public class SimpleNavMeshAgent : MonoBehaviour
{
    public Transform target;
    public GameObject waypointContainer;
    public float detectionRange;
    private NavMeshAgent agent;
    private Transform[] waypoints;
    private int waypointIndex;
    private bool currentlyChasing;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        GrabWaypoints();
        agent.SetDestination(waypoints[0].position);
    }
    
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= detectionRange)
        {
            currentlyChasing = true;
            agent.SetDestination(target.position);
            //Debug.Log("Chasing");
        }
        if (distance > detectionRange)
        {
            currentlyChasing = false;
            //Debug.Log("Not Chasing");
        }
        if (!currentlyChasing)
        {
            agent.SetDestination(waypoints[waypointIndex].position);
            if (agent.remainingDistance < agent.stoppingDistance + 0.1f)
            {
                //Debug.Log((waypointIndex + 1) % waypoints.Length);
                waypointIndex = (waypointIndex + 1) % waypoints.Length;
                agent.SetDestination(waypoints[waypointIndex].position);
            }
        }
    }

    private void GrabWaypoints()
    {
        int childrenCount = waypointContainer.transform.childCount;
        waypoints = new Transform[childrenCount];
        for (int i = 0; i < childrenCount; i++)
        {
            Transform currentChild = waypointContainer.transform.GetChild(i);
            waypoints[i] = currentChild;
        }
    }
}
