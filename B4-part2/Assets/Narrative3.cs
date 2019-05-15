using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Narrative3 : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform police, killer, exit;
    public GameObject alarm;
    public Text display;
    private bool yikes, start;
    public GameObject indicator1, indicator2;
    void Start()
    {
        yikes = true;
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(police.position, alarm.transform.position) < 0.5f && yikes)
        {
            StartCoroutine(set(3.0f));
            yikes = false;
            alarm.SetActive(true);
        }
        if (indicator1.activeSelf && indicator2.activeSelf && (Vector3.Distance(killer.position, exit.position) < 0.5f))
        {
            display.text = "How Many Did You Save? Game Over!";
        }

    }
    IEnumerator set(float t)
    {
        display.text = "Fire Alarm Activated By Guard!";
        yield return new WaitForSeconds(t);
        display.text = "Everyone Ran! Game Over!";
    }

}
