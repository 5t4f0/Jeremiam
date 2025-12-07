using System;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float Damage;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Tour"))
        {
            other.gameObject.GetComponent<TowerScript>().health -= Damage;
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
