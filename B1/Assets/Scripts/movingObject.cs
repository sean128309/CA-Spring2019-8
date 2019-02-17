using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingObject : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public float speed;
    private bool goUp = false;
    void Update()
    {
        if(goUp)
        {
            transform.Translate(0.0f, 0.0f, speed);
            if (transform.position.z >= 25.0f)
            {
                goUp = false;
            }
        }
        else
        {
            transform.Translate(0.0f, 0.0f, speed * -1);
            if (transform.position.z <= -25.0f)
            {
                goUp = true;
            }
        }
        
    }
}
