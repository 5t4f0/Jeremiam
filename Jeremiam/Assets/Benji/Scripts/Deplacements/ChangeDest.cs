using System;
using UnityEngine;

public class ChangeDest : MonoBehaviour
{
    public Transform NewTarget;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ennemi")
        {
            Debug.Log("Carré");
               GoTo goTo = other.GetComponent<GoTo>();
            if (goTo != null)
            {
                goTo.Agent.SetDestination(NewTarget.position);
            }
        }
        if (other.gameObject.tag == "FinalBoss")
        {
            Debug.Log("Carré");
            GoTo goTo = other.GetComponent<GoTo>();
            SpawningScript SS = other.GetComponent<SpawningScript>();
            if (goTo != null)
            {
                goTo.Agent.SetDestination(NewTarget.position);
            }

            if (SS != null)
            {
                SS.Stage++;
            }
                
        }
    }
}
