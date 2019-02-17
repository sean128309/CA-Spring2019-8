using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections.Generic;

public class MoveableObstacle : MonoBehaviour
{
    public float speedH = 1.0f;
    public float speedV = 1.0f;
    private GameObject selectedUnit;
    void Start()
    {
        deselect();
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(selectedUnit != null)
        {
            float moveV = Input.GetAxis("Vertical") * speedV;
            float moveH = Input.GetAxis("Horizontal") * speedH;
            selectedUnit.transform.Translate(moveH, 0.0f, moveV);

        }
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            if (selectedUnit != null) makeBlue(selectedUnit);
            if (hit.transform.tag == "Obstacle" )
            {
                
                if (selectedUnit == hit.transform.gameObject)
                {
                   
                    deselect();
                }
                else
                {
                    selectedUnit = hit.transform.gameObject;
                    makeGreen(selectedUnit);
                }
            }
            else
            {
                
                deselect();
            }
        }
    }
    void deselect()
    {
        selectedUnit = null;
    }
    void makeGreen(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.color = Color.green;
    }
    void makeBlue(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.color = Color.blue;
    }
}