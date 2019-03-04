using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zoe;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - zoe.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = zoe.transform.position + offset;
    }
}
