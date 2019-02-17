using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections.Generic;
public class ChooseAndMove : MonoBehaviour
{
    
    private NavMeshAgent agent;

    private bool selected;
    private GameObject selectedUnit;
    private Vector3 MoveTo, offset;
    private bool Move;
    private List<GameObject> pickedUnits = new List<GameObject>(); 

    void Start()
    {
        Move = false;
        agent = gameObject.GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            
            if (hit.transform.tag == "Player")
            {
                selectedUnit = hit.transform.gameObject;

                selected = false;
                for (int i = 0; i < pickedUnits.Count; i++)
                {
                    if(pickedUnits[i] == selectedUnit)
                    {
                        pickedUnits.RemoveAt(i);
                        makeRed(selectedUnit);
                        selected = true;
                        break;
                    }
                }
                if(!selected)
                {
                    pickedUnits.Add(selectedUnit);
                    makeGreen(selectedUnit);
                }
                
                
                
            }
                    

                
            if (hit.transform.tag != "Player" && Input.GetMouseButtonDown(0))
            {
                Destination(hit.point);
                //Debug.Log(hit.point);
            }
            /*if (hit.transform.tag != "Player" && Input.GetMouseButtonDown(0))
            {
                Deselect();
                Debug.Log("deselect");
            }*/



        }
        if (Move)
        {
            //Debug.Log("moving");
            for (int i = 0; i < pickedUnits.Count; i++)
            {
                agent = pickedUnits[i].GetComponent<NavMeshAgent>();
                int j = (i + 1) / 2;
                if (i % 2 == 0)offset = new Vector3(0.0f, 0.0f, agent.radius * j * 2);
                else offset = new Vector3(0.0f, 0.0f, agent.radius * j * -2);
                
                agent.SetDestination(MoveTo + offset);
                makeRed(pickedUnits[i]);
            }
            pickedUnits.Clear();
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
    }

    void makeGreen(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.color = Color.green;
    }
    void makeRed(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.color = Color.red;
    }
}