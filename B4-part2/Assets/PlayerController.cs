using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    public float speed, angularspeed;
    public Transform police, alarm;
    private Transform mypos;
    private bool hit;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        mypos = GetComponent<Transform>();
        hit = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float lr = Input.GetAxis("Horizontal");
        //Debug.Log(move);
        anim.SetFloat("Speed", move * speed);
        anim.SetFloat("AngularSpeed", lr * angularspeed);
        if(Vector3.Distance(police.position, alarm.position) < 0.5f)
        {
            speed = 0.0f;
            
        }
        if (Vector3.Distance(mypos.position, police.position) <= 1.5f && hit)
        {
            
            StartCoroutine(set(0.8f));
            hit = false;

        }

    }
    IEnumerator set(float t)
    {
        anim.SetBool("HandAnimation", true);
        anim.SetTrigger("H_Bash");
        yield return new WaitForSeconds(t);
        anim.SetBool("HandAnimation", false);
        anim.SetBool("Exit", true);
    }
    
}
