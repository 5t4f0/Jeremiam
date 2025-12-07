using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public ObjectDatabaseSO database;
    public int id;

    float health;
    float damage;
    float attackSpeed;
    float range;
    ObjectData.AttackMode targetMode;

    GameObject currentTarget;

    [SerializeField]
    private Transform attackPoint;
    [SerializeField] private GameObject projectile;

    void Awake()
    {
        health = database.objectsData[id].Health;
        damage = database.objectsData[id].Damage;
        attackSpeed = database.objectsData[id].AttackSpeed;
        range = database.objectsData[id].Range;
        targetMode = database.objectsData[id].Target;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag("Ennemi");

        float nearestDistance = Mathf.Infinity;
        Vector3 towerPosition = transform.position;

        foreach (GameObject ennemy in ennemies)
        {
            float dist = Vector3.Distance(towerPosition, ennemy.transform.position);
            if (dist < nearestDistance)
            {
                nearestDistance = dist;
                currentTarget = ennemy;
            }
        }
    }

    void Shoot()
    {

    }
}
