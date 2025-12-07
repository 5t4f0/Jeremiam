using System;
using UnityEngine;
using UnityEngine.AI;

public enum Type
{
    air,
    ground
}

public class Caractéristique : MonoBehaviour
{
    public float HP;
    public float speed;

    public Type type; 

    private void Start()
    {
        if(GetComponent<NavMeshAgent>()==null)
        {
            return;
        }
        else
        {
            GetComponent<NavMeshAgent>().speed = speed;
        }
    }

    private void FixedUpdate()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
