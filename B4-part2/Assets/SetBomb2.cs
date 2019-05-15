using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBomb2 : MonoBehaviour
{
    public Transform killer;
    public Transform setpoint;
    public GameObject bomb;
    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(killer.position, setpoint.position) < 0.5f)
        {
            
            bomb.SetActive(true);
        }
    }
}
