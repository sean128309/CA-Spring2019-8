using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float cameraspeed;
    public float cameraDistanceMax = 20f;
    public float cameraDistanceMin = 5f;
    public float cameraDistance = 5f;
    public float scrollSpeed = 0.5f;
    private Vector3 offset;

    
    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical");
        float lr = Input.GetAxis("Horizontal");
        
        Vector3 movements = new Vector3(lr, move, 0.0f);
        
        transform.Translate(movements * cameraspeed);
        //cameraDistance += Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        //cameraDistance = Mathf.Clamp(cameraDistance, cameraDistanceMin, cameraDistanceMax);
        //Debug.Log(cameraDistance - transform.position.y);
        transform.Translate(0.0f,  0.0f, Input.GetAxis("Mouse ScrollWheel") * scrollSpeed);
    }
}
