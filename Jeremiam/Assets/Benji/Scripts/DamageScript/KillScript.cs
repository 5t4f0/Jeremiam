using System;
using UnityEngine;

public class KillScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ennemi")
        {
            Destroy(other.gameObject);
        }
    }
}
