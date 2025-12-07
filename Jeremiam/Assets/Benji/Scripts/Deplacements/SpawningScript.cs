using System;
using Unity.VisualScripting;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public GameObject Legume;
    public GameObject Cactus;
    public Transform SpawnPoint;
    public int Stage = 1;
    public Waves Waves;


    private void Start()
    {
        if (Waves.WaveNumber == 2)
        {
            Instantiate(Cactus,SpawnPoint.position,Quaternion.identity);
        }
    }

    public void SpawnLegume()
    {
        GameObject clone = Legume;
        clone.GetComponent<GoTo>().Stage = Stage;
        Instantiate(clone,SpawnPoint.position,Quaternion.identity);
        
        Waves.AddCountDown();
         
    }
    
}
