using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections.Generic;
public class ChooseAndMove : MonoBehaviour
{
    Animator anim;
    private NavMeshAgent agent;
    private bool selected;
    private GameObject selectedUnit;
    private Vector3 MoveTo, offset;
    private bool Move;
    private List<GameObject> pickedUnits = new List<GameObject>();
    int runhash = Animator.StringToHash("Run");
    int walkhash = Animator.StringToHash("Walk");
    int jump = Animator.StringToHash("jump");
    private bool jumptriggered = false;
    private bool running = false;
    public float runspeed, walkspeed;
    void Start()
    {
        anim = GetComponent<Animator>();
        Move = false;
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (agent.isOnOffMeshLink && !jumptriggered)
        {
            anim.SetTrigger(jump);
            jumptriggered = true;
            Debug.Log("triggered");
        }
        if (!agent.isOnOffMeshLink)
        {
            jumptriggered = false;
        }
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(1))
        {

            if (hit.transform.tag == "Players")
            {
                selectedUnit = hit.transform.gameObject;
                selected = false;
                //Debug.Log(pickedUnits.Count);
                for (int i = 0; i < pickedUnits.Count; i++)
                {
                    //Debug.Log("i=");
                    //Debug.Log(i);
                    if (pickedUnits[i] == selectedUnit)
                    {

                        turnOffCircle(pickedUnits[i]);
                        pickedUnits.RemoveAt(i);
                        selected = true;
                        break;
                    }
                }
                if (!selected)
                {
                    pickedUnits.Add(selectedUnit);
                    turnOnCircle(selectedUnit);
                }



            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            Destination(hit.point);
            running = false;
            agent.speed = walkspeed;
            //Debug.Log("walk");
        }

        if (Input.GetMouseButtonDown(2))
        {
            if (!running)
            {
                anim.SetTrigger(runhash);
                //Destination(hit.point);
                //Debug.Log("run");
                running = true;
                agent.speed = runspeed;
            }
            else
            {
                anim.SetTrigger(walkhash);
                running = false;
                agent.speed = walkspeed;
            }

        }




        if (agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            Move = false;
            
        }

    }

    void Destination(Vector3 d)
    {
        MoveTo = d;
        Move = true;
        for (int i = 0; i < pickedUnits.Count; i++)
        {
            agent = pickedUnits[i].GetComponent<NavMeshAgent>();
            int j = (i + 1) / 2;
            if (i % 2 == 0) offset = new Vector3(0.0f, 0.0f, agent.radius * j * 2);
            else offset = new Vector3(0.0f, 0.0f, agent.radius * j * -2);

            agent.SetDestination(MoveTo + offset);
            turnOffCircle(pickedUnits[i]);
        }
        pickedUnits.Clear();
    }

    void turnOnCircle(GameObject obj)
    {
        GameObject circle = obj.transform.GetChild(4).gameObject;
        circle.SetActive(true);
    }
    void turnOffCircle(GameObject obj)
    {
        GameObject circle = obj.transform.GetChild(4).gameObject;
        circle.SetActive(false);
    }

    
}