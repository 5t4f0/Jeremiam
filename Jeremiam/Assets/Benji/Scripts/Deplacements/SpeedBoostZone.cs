using System;
using UnityEngine;

public class SpeedBoostZone : MonoBehaviour
{
    public float SpeedBoost;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ennemi"))
        {
            Debug.Log("yolerap");
            other.gameObject.GetComponent<Caractéristique>().speed = SpeedBoost;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Caractéristique>().speed = 5;
    }
}
