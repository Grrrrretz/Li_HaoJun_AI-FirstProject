using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class S_playercontroler : MonoBehaviour
{
    public LayerMask groundlayermask;
    private NavMeshAgent navAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        bool leftmouseClicked = Mouse.current.leftButton.wasPressedThisFrame;
        if (leftmouseClicked)
        {
          Vector3 mousepostion =  Mouse.current.position.ReadValue();
            //Vector3 worldposition = Camera.main.ScreenToWorldPoint(mousepostion);

            Ray mouseClickRay = Camera.main.ScreenPointToRay(mousepostion);
            RaycastHit mouseClickHit;

            if (Physics.Raycast(mouseClickRay, out mouseClickHit, 25F, groundlayermask))
            {
                navAgent.SetDestination(mouseClickHit.point);
            }
        }
    }
}
