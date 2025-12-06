using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public GameObject Legume;
    public GameObject Cactus;
    public Transform SpawnPoint;
    public int Stage = 1;
    void Start()
    {
        InvokeRepeating(nameof(SpawnLegume), 2f, 2f);
    }

    void SpawnLegume()
    {
        GameObject clone = Legume;
        clone.GetComponent<GoTo>().Stage = Stage;
        Instantiate(clone,SpawnPoint.position,Quaternion.identity);
        
    }
}
