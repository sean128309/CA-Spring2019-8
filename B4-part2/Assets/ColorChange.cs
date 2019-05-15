using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
