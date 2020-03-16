using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stethoscope : MonoBehaviour
{
    public GameObject StethoscopePrefab;
    public GameObject StethoscopeTrigger;
    public GameObject StethoscopeOnHand;

    public GameObject rightHand;

    public GameObject breathingArea;



    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        GrabStethoscope();


    }

    void GrabStethoscope()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            if (StethoscopeTrigger.GetComponent<GrabDetect>().isTrigered == true)
            {
                StethoscopeOnHand.SetActive(true);
                StethoscopeTrigger.SetActive(false);

            }
        }
        else if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        {
            if(StethoscopeTrigger.activeSelf == false)
            {
                StethoscopeOnHand.SetActive(false);
                Destroy(StethoscopeTrigger);
                StethoscopeTrigger = Instantiate(StethoscopePrefab, rightHand.transform.position, Quaternion.identity);
                StethoscopeTrigger.GetComponent<GrabDetect>().isTrigered = false;
            }
                    
        }
       
        void PositionControl()
        {

        }
      
        
        
        
    }
    

    
}
