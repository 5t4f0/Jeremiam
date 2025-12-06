using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ennemi")
        {
            Debug.Log("Ennemi");
            SceneManager.LoadScene("Benji/jspckoi");
        }
    }
}
