using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Transform main;
    public GameObject camera;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

        offset = camera.transform.position - main.position;

    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = main.position + offset;

    }
   
}
