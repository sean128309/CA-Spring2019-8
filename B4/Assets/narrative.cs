using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class narrative : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform t1, t2, t3,t4, cam;
    public Text display;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(t1.position,cam.position) < 0.5f)
        {
            display.text = "People are visiting the amazing arts.";
        }
        if (Vector3.Distance(t2.position, cam.position) < 0.5f)
        {
            display.text = "A mysterious man assaults the guard";
        }
        if (Vector3.Distance(t3.position, cam.position) < 0.5f)
        {
            display.text = "He plants bombs and flees";
        }
        if (Vector3.Distance(t4.position, cam.position) < 0.5f)
        {
            display.text = "People realize what's happening and start fleeing";
        }
    }
}
