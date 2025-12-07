using UnityEngine;

public class TowerScript : MonoBehaviour
{
    public ObjectDatabaseSO database;
    public int id;

    float health;
    float damage;
    float attackSpeed;
    private float attackSpeedDef;
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
        attackSpeedDef = database.objectsData[id].AttackSpeed;
        range = database.objectsData[id].Range;
        targetMode = database.objectsData[id].Target;

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (attackSpeed <= 0f)
        {
            Shoot();
            attackSpeed = attackSpeedDef;
        }



        attackSpeed -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ennemi");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            if ((enemy.GetComponent<Caractéristique>().type == Type.air && targetMode == ObjectData.AttackMode.Air) || (enemy.GetComponent<Caractéristique>().type == Type.ground && targetMode == ObjectData.AttackMode.Ground))
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            currentTarget = nearestEnemy;
        }
        else
        {
            currentTarget = null;
        }
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(projectile, attackPoint.position, attackPoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(currentTarget.transform);
    }
}
