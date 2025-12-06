using System;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float Damage;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Tour"))
        {
            other.gameObject.GetComponent<Caractéristique>().HP -= Damage;
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
