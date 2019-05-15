using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToldToRun : MonoBehaviour
{
    public Transform main;
    private Transform mypos;
    public GameObject alarm;
    // Start is called before the first frame update
    void Start()
    {
        mypos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(main.position, mypos.position) < 1.5f)
        {
            alarm.SetActive(true);
        }
    }
}
