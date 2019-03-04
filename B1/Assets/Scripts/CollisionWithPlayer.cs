using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollisionWithPlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 Moveto;
    public float nazeRadius = 3.0f;
    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player" && col.gameObject.name != "naze")
        {
            agent = col.gameObject.GetComponent<NavMeshAgent>();
            Moveto = col.gameObject.transform.position - gameObject.transform.position;
            Debug.Log(Moveto.magnitude);
            Moveto = Moveto / Moveto.magnitude * (nazeRadius - Moveto.magnitude);
            agent.SetDestination(col.gameObject.transform.position + Moveto);
        }
    }
}
