using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TreeSharpPlus;



public class Sitting : MonoBehaviour
{
    // Start is called before the first frame update
    
    Animator anim;
    void Start()
    {
        GetComponent<BodyMecanim>().SitDown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
