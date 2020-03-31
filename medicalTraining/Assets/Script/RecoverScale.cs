/************************************************************************************
Filename    :   RecoverScale.cs
Content     :   Turn off scaled object and active the object in original size
************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverScale : MonoBehaviour
{
    public GameObject originalObj;

    private OVRGrabbable scaleGrabbable;

    // Start is called before the first frame update
    void Start()
    {
        scaleGrabbable = this.transform.GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.scaleGrabbable.isGrabbed == true)
        {
            originalObj.SetActive(true);
            this.gameObject.SetActive(false);
            this.scaleGrabbable.grabbedBy.gameObject.GetComponent<OVRGrabber>().ForceRelease(this.scaleGrabbable);
        }
    }
}
