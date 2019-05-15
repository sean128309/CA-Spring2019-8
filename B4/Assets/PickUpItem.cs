using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject item;
    GameObject dropitem;
    public Transform guide;
    public Transform pickPoint;
    public Transform dropPoint;
    public GameObject tempParent;
    public GameObject oriParent;
    private Vector3 offset;
    int gold_no;
    bool takeandgo;


    bool carrying;
    void Start()
    {
        gold_no = 0;
        nextitem();
        
        carrying = false;
        offset = new Vector3(0f, -0.3f, 0f);

        takeandgo = false;
    }


    // Update is called once per frame
    void Update()
    {
       // Debug.Log(gold_no);
        if (!carrying && Vector3.Distance(guide.position, pickPoint.position) <= 1.5f)
        {
            
            Invoke("pickup", 1.5f);
            
            carrying = true;
            
        }
        
        if (carrying && Vector3.Distance(guide.transform.position, dropPoint.position) <= 1.5f)
        {
            //item.tag = "Stolen";
            dropitem = item;
            Invoke("drop", 1.2f);
            nextitem();
            carrying = false;
            
        }

        /*if(Input.GetKeyDown("space") || oriParent.transform.childCount == 5)
        {
            //Debug.Log("proc");
            takeandgo = true;
        }

        if(takeandgo && Vector3.Distance(guide.transform.position, dropPoint.position) <= 1.5f)
        {
            //Debug.Log("proc2");
            oriParent.SetActive(false);
        }*/
        
    }
    void pickup()
    {
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.position = guide.transform.position;
        item.transform.rotation = guide.transform.rotation;
        item.transform.parent = tempParent.transform;
       
    }
    void drop()
    {
        dropitem.GetComponent<Rigidbody>().useGravity = true;
        dropitem.GetComponent<Rigidbody>().isKinematic = false;
        dropitem.transform.parent = oriParent.transform;
        dropitem.transform.position = guide.transform.position;
        dropitem.tag = "Stolen";
        
        
    }
    void nextitem()
    {
        foreach (Transform child in transform)
        {
            //Debug.Log("all" +child.tag);
           // Debug.Log("=?" + gold_no.ToString());
            if (child.tag == gold_no.ToString())
            {
                //Debug.Log("inside" + child.tag);
                item = child.gameObject;
                item.GetComponent<Rigidbody>().useGravity = true;
            }
        }
        gold_no += 1;
        //Debug.Log(gold_no);
        //Debug.Log(item.tag);
    }
    
}
