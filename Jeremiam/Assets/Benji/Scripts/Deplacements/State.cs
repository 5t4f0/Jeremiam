using UnityEngine;

public class State : MonoBehaviour
{
    public GoTo GT;
    public bool SaladGo = false;
    void Start()
    {
        GT = GetComponent<GoTo>();
        GT.enabled = false;
    }
    
    void FixedUpdate()
    {
        if (SaladGo)
        {
            GT.enabled = true;
        }
    }
}
