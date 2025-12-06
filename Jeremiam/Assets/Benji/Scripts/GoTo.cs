using System;
using Unity.VisualScripting;
using UnityEngine;

public class GoTo : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent Agent;
    public Transform target;
    public Transform targetA;
    private void Start()
    {
        target = targetA;
        Agent.SetDestination(target.position);
    }
}
