using System;
using UnityEngine;
using UnityEngine.AI;

public class Caractéristique : MonoBehaviour
{
    public float HP;
    public float speed;
    
    private void FixedUpdate()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        if(GetComponent<NavMeshAgent>()==null)
        {
            return;
        }
        else
        {
            GetComponent<NavMeshAgent>().speed = speed;
        }
        
        
    }
}
