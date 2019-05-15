using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOffAlarm : MonoBehaviour
{
    public GameObject alarm;
    public GameObject bomb1;
    public GameObject bomb2;
    public Transform killer;
    public Transform killer_exit;
    private float a;
    private bool laydown;
    // Start is called before the first frame update
    void Start()
    {
        laydown = true; 
        a = Random.Range(-25.0f, -7.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(killer.position.z <= a && !alarm.activeSelf && (bomb1.activeSelf || bomb2.activeSelf))
        {
            alarm.SetActive(true);
        }
        if(killer_exit.position.x - killer.position.x <= 0.5f && laydown)
        {
            alarm.SetActive(false);

            StartCoroutine(set(0.5f));

        }
        if(!laydown)
        {
            alarm.SetActive(true);
        }
       
    }
    IEnumerator set(float t)
    {
        yield return new WaitForSeconds(t);
        laydown = false;
    }
}
