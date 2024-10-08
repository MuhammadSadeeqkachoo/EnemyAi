using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Camera m_Camera;
    [SerializeField]
    NavMeshAgent agent;
    [SerializeField]
    Transform red_Transform;



    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
        //{
        //    Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        // Do something with the object that was hit by the raycast
        //        Debug.Log("Hit object: " + hit.point);
        //        agent.SetDestination(hit.point);
        //    }
        //}

        agent.SetDestination(red_Transform.position);


    }
}
