using System;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    public GameObject Drop;
    public Transform targetB;
    public Transform targetA;
    private void OnDestroy()
    {
        Instantiate(Drop, transform.position, Quaternion.identity);
        Instantiate(Drop, targetA.position, Quaternion.identity);
        Instantiate(Drop, targetB.position, Quaternion.identity);
    }
}
