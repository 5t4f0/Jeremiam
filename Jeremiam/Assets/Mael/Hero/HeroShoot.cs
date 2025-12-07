using UnityEngine;

public class HeroShoot : MonoBehaviour
{
    public float damage = 2;
    public float range;
    public float attackSpeed = 2;
    private float attackSpeedDef;

    GameObject currentTarget;

    [SerializeField]
    private Transform attackPoint;
    [SerializeField] private GameObject projectile;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        attackSpeedDef = attackSpeed;
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
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        currentTarget = nearestEnemy;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(projectile, attackPoint.position, attackPoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        bullet.damage = damage;

        if (bullet != null)
            bullet.Seek(currentTarget);
    }
}
