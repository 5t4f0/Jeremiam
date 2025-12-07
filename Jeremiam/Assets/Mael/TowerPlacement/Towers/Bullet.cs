using UnityEngine;

public class Bullet : MonoBehaviour
{

    private GameObject target;

    public float speed = 70f;

    public float damage;

    public void Seek(GameObject _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
            Debug.Log(target);

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target.transform);

    }

    void HitTarget()
    {
        Damage(target);

        Destroy(gameObject);
    }

    void Damage(GameObject enemy)
    {
        enemy.GetComponent<Caractéristique>().HP -= damage;
    }
}