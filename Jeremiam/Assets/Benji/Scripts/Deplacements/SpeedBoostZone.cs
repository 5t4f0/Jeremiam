using System;
using UnityEngine;

public class SpeedBoostZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ennemi"))
        {
            other.gameObject.GetComponent<Caractéristique>().speed = 10;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Caractéristique>().speed = 5;
    }
}
