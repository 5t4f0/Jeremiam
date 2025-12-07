using System;
using UnityEngine;


public class Waves : MonoBehaviour
{
    public GameObject FinalBoss;
    public GameObject Spawn;
    public GameObject Spawn2;
    private SpawningScript FBSS;
    private SpawningScript SSS;
    private SpawningScript S2SS;
    
    public int WaveNumber = 1;
    public int EnnemiNumber = 3;
    public int CountDown = 0;
    public int Randum=1;
    public int MoreEnnemies;

    private void Start()
    {
        FBSS=FinalBoss.GetComponent<SpawningScript>();
        SSS=Spawn.GetComponent<SpawningScript>();
        S2SS=Spawn2.GetComponent<SpawningScript>();
        StartWave();
    }

    private void FixedUpdate()
    {
        Randum=UnityEngine.Random.Range(1,4);
        if (WaveNumber == 1)
        {
            EnnemiNumber = 3+MoreEnnemies;
        }

        if (WaveNumber == 2)
        {
            EnnemiNumber = 4+MoreEnnemies;
        }

        if (WaveNumber == 3+)
        {
            EnnemiNumber = 5+MoreEnnemies;
        }
    }

    public void StartWave()
     {
         InvokeRepeating(nameof(spawn), 2f, 1f);
     }
    
    public void EndWave()
     {
         CancelInvoke("spawn");
     }

    public void spawn()
    {
        if (Randum == 1)
        {
            FBSS.SpawnLegume();
            
        }

        if (Randum == 2)
        {
            SSS.SpawnLegume();
            
        }
        if (Randum == 3)
        {
            S2SS.SpawnLegume();
            
        }
        
    }
    
    public void AddCountDown()
    {
        CountDown++;
        
        if (CountDown == EnnemiNumber)
        {
            EndWave();
        }
    }
}
