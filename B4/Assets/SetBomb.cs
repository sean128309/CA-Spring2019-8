using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBomb : MonoBehaviour
{

    public Transform killer;
    public Transform setpoint;
    public GameObject bomb;
    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(killer.position,setpoint.position) < 0.5f)
        {
            StartCoroutine(set(1.0f));


        }
    }
    IEnumerator set(float t)
    {
        yield return new WaitForSeconds(t);
        bomb.SetActive(true);
    }
}
