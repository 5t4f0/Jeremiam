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
                goTo.target = NewTarget;
                goTo.Agent.SetDestination(goTo.target.position);
            }
        }
    }
}
