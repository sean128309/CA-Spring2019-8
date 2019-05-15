using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public Transform target1, target2, target3, target4;
    public float speed = 2.0f;
    private bool firstmove, secondmove, firststop,secondstop, thirdmove, thirdstop, fourthmove, fourthstop;
    // Start is called before the first frame update
    void Start()
    {
        firstmove = true;
        firststop = true;
        secondmove = false;
        secondstop = true;
        thirdmove = false;
        thirdstop = true;
        fourthmove = false;
        fourthstop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (firstmove)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target1.position, step);
        }
        if(Vector3.Distance(transform.position, target1.position)<0.5f && firststop)
        {
            //Debug.Log("!");
            firstmove = false;
            secondmove = true;
            firststop = false;
            StartCoroutine(delay(5.0f, 15.0f));
        }
        if (secondmove)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target2.position, step);
        }
        if (Vector3.Distance(transform.position, target2.position) < 0.5f && secondstop)
        {
            
            secondmove = false;
            thirdmove = true;
            secondstop = false;
            StartCoroutine(delay(13.0f, 2.0f));
        }
        if(thirdmove)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target3.position, step);
        }
        if (Vector3.Distance(transform.position, target3.position) < 0.5f && thirdstop)
        {

            thirdmove = false;
            fourthmove = true;
            thirdstop = false;
            StartCoroutine(delay(22.0f, 2.0f));
        }
        if(fourthmove)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target4.position, step);
        }

    }
    IEnumerator delay(float t, float changeto)
    {
        speed = 0.0f;
        yield return new WaitForSeconds(t);
        speed = changeto;
    }
}
