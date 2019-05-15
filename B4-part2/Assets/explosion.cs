using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public Transform killer;
    public Transform exit;
    public GameObject explosion1;
    public GameObject bomb1;
    public GameObject bomb2;
    public GameObject explosion2;
    public GameObject indicator1;
    public GameObject indicator2;
    public GameObject alarm;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(killer.position, exit.position) < 0.5f)
        {
            if (bomb1.activeSelf)
            {
                explosion1.SetActive(true);
                bomb1.SetActive(false);
                indicator1.SetActive(true);
                StartCoroutine(set(0.3f));
            }
            if (bomb2.activeSelf)
            {
                explosion2.SetActive(true);
                bomb2.SetActive(false);
                indicator2.SetActive(true);
                StartCoroutine(set(0.3f));
            }
        }
        
       
        
    }
    IEnumerator set(float t)
    {
        alarm.SetActive(true);
        yield return new WaitForSeconds(t);
        alarm.SetActive(false);
    }

}
