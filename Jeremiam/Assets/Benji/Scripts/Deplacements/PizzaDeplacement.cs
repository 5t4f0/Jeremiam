using UnityEngine;

public class PizzaDeplacement : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public GameObject Bomb;
    private bool hasArrived = false;
    public Transform firingPoint;
    public float AttackSpeed;
    private GameObject nearestTour = null;
    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Start()
    {
        SetDestinationToNearestTower();
    }


    void Update()
    {
        SetDestinationToNearestTower();
        if (!hasArrived && !agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    hasArrived = true;

                    Debug.Log("Est arrivé");
                    ArrivedAtDestination();
                }

                else
                {
                    CancelInvoke(nameof(BombMeth));
                }
            }
        }

        Debug.Log(nearestTour);

    }

    void SetDestinationToNearestTower()
    {
        GameObject[] tours = GameObject.FindGameObjectsWithTag("Tour");

        if (tours.Length == 0)
        {
            return;
        }

        float nearestDistance = Mathf.Infinity;
        Vector3 pizzaPosition = transform.position;

        foreach (GameObject tour in tours)
        {
            float dist = Vector3.Distance(pizzaPosition, tour.transform.position);
            if (dist < nearestDistance)
            {
                nearestDistance = dist;
                nearestTour = tour;
            }
        }

        if (nearestTour != null && agent != null)
        {
            agent.SetDestination(nearestTour.transform.position);
        }
    }
    void ArrivedAtDestination()
    { 
        Debug.Log("ArrivedAtDestination");
        InvokeRepeating(nameof(BombMeth),0.5f,AttackSpeed);


    }

    void BombMeth()
    {
        if(nearestTour.GetComponent<Caractéristique>().HP!=0 && agent.velocity.sqrMagnitude == 0f)
        {
            Instantiate(Bomb,firingPoint.position, Quaternion.identity);
            Debug.Log("appelé");
        }

        else
        {
            CancelInvoke(nameof(BombMeth));
            hasArrived = false;
        }


    }


} 
