/************************************************************************************
Filename    :   Stethscope.cs
Content     :   Control the stethoscope in hand and on crashcart
************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stethoscope : MonoBehaviour
{
    public GameObject StethoscopeTrigger; //Stethoscope on crashcart
    public GameObject StethoscopeOnHand; //Stethscope in hand

    public GameObject rightHand;

    public GameObject breathingArea; //area for triggering breathing sound
    public GameObject centerPoint; //the standard position fo the chest

    public bool isUse;

    // Update is called once per frame
    void Update()
    {
        GrabStethoscope();

        PositionControl();

    }

    void GrabStethoscope() //Grab and release Stethscope
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

    void PositionControl() //Control the positon of the stethscope when hearing the breathing sound
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
