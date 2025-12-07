using UnityEngine;

public class ChangeDest2 : MonoBehaviour
{
    private Transform NewTarget;
    public Transform NewTarget1;
    public Transform NewTarget2;
    public int Way;
    
        private void FixedUpdate()
        {
            Way =Random.Range(1,3);
            if (Way == 1)
            {
                NewTarget = NewTarget1;
            }
            else
            {
                NewTarget = NewTarget2;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Ennemi")
            {
                Debug.Log("Carré");
                   GoTo goTo = other.GetComponent<GoTo>();
                if (goTo != null)
                {
                    goTo.Agent.SetDestination(NewTarget.position);
                }
            }
            if (other.gameObject.tag == "FinalBoss")
            {
                Debug.Log("Carré");
                GoTo goTo = other.GetComponent<GoTo>();
                SpawningScript SS = other.GetComponent<SpawningScript>();
                if (goTo != null)
                {
                    goTo.Agent.SetDestination(NewTarget.position);
                }
    
                if (SS != null)
                {
                    SS.Stage++;
                }
                    
            }
        }
}
