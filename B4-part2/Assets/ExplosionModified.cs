using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionModified : MonoBehaviour
{
    public Transform killer;
    public Transform exit;
    public GameObject explosion1;
    public GameObject bomb1;
    public GameObject bomb2;
    public GameObject explosion2;
    public GameObject indicator1;
    public GameObject indicator2;
    public GameObject alarm1, alarm2, alarm3, alarm4, alarm5, alarm6, alarm7, alarm8, alarm9, alarm10, alarm11, alarm12;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(killer.position, exit.position) < 0.5f)
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
        alarm1.SetActive(true);
        alarm2.SetActive(true);
        alarm3.SetActive(true);
        alarm4.SetActive(true);
        alarm5.SetActive(true);
        alarm6.SetActive(true);
        alarm7.SetActive(true);
        alarm8.SetActive(true);
        alarm9.SetActive(true);
        alarm10.SetActive(true);
        alarm11.SetActive(true);
        alarm12.SetActive(true);
        yield return new WaitForSeconds(t);
        alarm1.SetActive(false);
        alarm2.SetActive(false);
        alarm3.SetActive(false);
        alarm4.SetActive(false);
        alarm5.SetActive(false);
        alarm6.SetActive(false);
        alarm7.SetActive(false);
        alarm8.SetActive(false);
        alarm9.SetActive(false);
        alarm10.SetActive(false);
        alarm11.SetActive(false);
        alarm12.SetActive(false);
    }

}
