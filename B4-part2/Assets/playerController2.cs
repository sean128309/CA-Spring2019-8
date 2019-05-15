using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController2 : MonoBehaviour
{
    private Animator anim;
    public float speed, angularspeed;
    public Transform killer;
    private Transform mypos;
    public GameObject alarm;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        mypos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float lr = Input.GetAxis("Horizontal");
        //Debug.Log(move);
        anim.SetFloat("Speed", move * speed);
        anim.SetFloat("AngularSpeed", lr * angularspeed);
        Debug.Log(Vector3.Distance(killer.position, mypos.position));
        if (Vector3.Distance(killer.position, mypos.position) < 1.5f)
        {
            speed = 0.0f;
            anim.SetTrigger("B_Dying");
        }
        if (Vector3.Distance(alarm.transform.position, mypos.position) < 0.5f)
        {
            alarm.SetActive(true);
        }
    }
}
