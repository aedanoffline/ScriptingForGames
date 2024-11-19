using UnityEngine;
using UnityEngine.AI;

public class SimpleNavMeshAgent : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }
    
    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}
