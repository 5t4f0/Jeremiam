using System;
using Unity.VisualScripting;
using UnityEngine;

public class GoTo : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent Agent;
    public string Dest = "DestA";
    public int Stage;
    private void Start()
    {
        if (Stage == 1)
        {
            Dest = "DestA";
        }
        if (Stage == 2)
        {
            Dest = "DestB";
        }
        if (Stage == 3)
        {
            Dest = "DestC";
        }
        if (Stage == 4)
        {
            Dest = "DestD";
        }
        GameObject target = GameObject.FindGameObjectWithTag(Dest);
        Agent.SetDestination(target.transform.position);
    }
    
}
