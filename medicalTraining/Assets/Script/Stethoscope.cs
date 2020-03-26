using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stethoscope : MonoBehaviour
{
    public GameObject StethoscopeTrigger;
    public GameObject StethoscopeOnHand;

    public GameObject rightHand;

    public GameObject breathingArea;
    public GameObject centerPoint;

    public bool isUse;



    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        GrabStethoscope();

        PositionControl();

    }

    void GrabStethoscope()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            if (StethoscopeTrigger.GetComponent<GrabDetect>().isTrigered == true)
            {
                StethoscopeOnHand.SetActive(true);
                StethoscopeTrigger.SetActive(false);
                isUse = true;
            }
        }
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            if(StethoscopeOnHand.activeSelf == true)
            {
                StethoscopeOnHand.SetActive(false);
                StethoscopeTrigger.SetActive(true);
                StethoscopeTrigger.transform.position = rightHand.transform.position;
                StethoscopeTrigger.GetComponent<GrabDetect>().isTrigered = false;
                isUse = false;
            }
                    
        }
       
       
      
        
        
        
    }
    void PositionControl()
    {
        if (breathingArea.GetComponent<CollisionDetection>().isTriggered == true)
        {
            StethoscopeOnHand.transform.position = new Vector3(StethoscopeOnHand.transform.position.x, centerPoint.transform.position.y, StethoscopeOnHand.transform.position.z);
           
            if (Vector3.Distance(StethoscopeOnHand.transform.position, rightHand.transform.position) > 0.1)
            {
                breathingArea.GetComponent<CollisionDetection>().isTriggered = false;
            }
        }
        else

            StethoscopeOnHand.transform.localPosition = Vector3.zero;
    }


}
