using UnityEngine;
using UnityEngine.AI;


public class S_ScoutMovement : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public Vector3 disran;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        navAgent.SetDestination(disran);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
