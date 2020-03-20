using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObjects : MonoBehaviour
{
    private OVRGrabbable grabbable;

    private GameObject leftHand;
    private GameObject rightHand;

    private bool scale;
    private bool record;
    private bool doubleHands;

    private Vector3 originalScale;
    private Vector3 left;
    private Vector3 right;


    // Start is called before the first frame update
    void Start()
    {
        grabbable = this.transform.GetComponent<OVRGrabbable>();
        originalScale = this.transform.localScale;

        leftHand = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/LeftHandAnchor/LeftControllerAnchor/CustomHandLeft");
        rightHand = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/RightHandAnchor/RightControllerAnchor/CustomHandRight");
    }

    // Update is called once per frame
    void Update()
    {
        doubleHands = this.transform.Find("Plane").GetComponent<HandDetection>().isHand;
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            if (grabbable.isGrabbed == true && doubleHands == true)
            {
                if (record == false && scale == false)
                {
                    left = leftHand.transform.position;
                    right = rightHand.transform.position;
                    record = false;
                    scale = true;
                }

                if (scale == true)
                {
                    float oldDis = Vector3.Distance(left, right);
                    float NewDis = Vector3.Distance(leftHand.transform.position, rightHand.transform.position);
                    float offSet = NewDis - oldDis;

                    float scaleFactor = offSet / 200;
                    Vector3 localScale = transform.localScale;
                    Vector3 Scale = new Vector3(localScale.x + scaleFactor, localScale.y, localScale.z + scaleFactor);

                    if (Scale.x > originalScale.x && Scale.z > originalScale.z)
                    {
                        transform.localScale = Scale;
                    }
                }
            }

            else
            {
                record = false;
                scale = false;
            }
        }
        
        
    }

 
  
}
