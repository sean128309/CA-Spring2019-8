using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class ClickAndMove : MonoBehaviour
{
    RaycastHit hitInfo = new RaycastHit();
    NavMeshAgent agent, thisagent;
    Vector3 lastAgentVelocity;
    NavMeshPath lastAgentPath;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
                agent.destination = hitInfo.point;
        }
    }
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("asd");
        pause();
        waiter();
        resume();
    }
    /*void OnTriggerExit(Collider col)
    {
        resume();
    }*/
    void pause()
    {
        lastAgentVelocity = agent.velocity;
        lastAgentPath = agent.path;
        agent.velocity = Vector3.zero;
        agent.ResetPath();
    }

    void resume()
    {
        agent.velocity = lastAgentVelocity;
        agent.SetPath(lastAgentPath);
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(10f);
        
    }
}