using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float runspeed;
    public float runrotatespeed;
    public float walkspeed;
    public float jumpPower;
    int runhash = Animator.StringToHash("Run");
    int turnright = Animator.StringToHash("turnright");
    int turnleft = Animator.StringToHash("turnleft");
    int jump = Animator.StringToHash("jump");
    Animator anim;
    Rigidbody rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical") ;
        float lr = Input.GetAxis("Horizontal") ;
        anim.SetFloat("VelocityX", move);
        anim.SetFloat("VelocityZ", lr);
        Vector3 movement = new Vector3(lr, 0.0f, move);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger(jump);
            rb.AddForce(0, jumpPower, 0);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger(turnright);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger(turnleft);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger(runhash);
            //transform.Translate(0, 0, move * runspeed);
            rb.AddForce(0, 0, move * runspeed);

            transform.Rotate(0, 0, lr * runrotatespeed);
            transform.Translate(0, transform.position.y * -1, 0);
            Debug.Log("running");
        }
        else
        {
            //transform.Translate(movement * walkspeed);
            rb.AddForce(movement * walkspeed);
            transform.Translate(0, transform.position.y * -1, 0);

        }
    }
}
