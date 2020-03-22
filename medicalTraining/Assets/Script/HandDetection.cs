using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDetection : MonoBehaviour
{
    public bool isHand;
    public OVRGrabbable grab;

    private GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (grab.isGrabbed == true)
        { 
            go = grab.grabbedBy.gameObject;

            if (other.name != go.name)
            {
                    isHand = true;
            }
        }
        else
            isHand = false;
    }

    void OnTriggerExit(Collider other)
    {
        if(grab.isGrabbed == false)
        {
            isHand = false;
        }

        if (grab.isGrabbed == true)
        {
            if (other.name != go.name)
            {
                isHand = true;
            }
        }
    }
}
