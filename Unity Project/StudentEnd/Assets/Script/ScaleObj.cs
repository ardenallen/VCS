/************************************************************************************
Filename    :   ScaleObj.cs
Content     :   Turn off the object and active the scaled object
************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObj : MonoBehaviour
{
    public GameObject scalePanel;

    private OVRGrabbable grabbable;
    private OVRGrabbable scaleGrabble;
    // Start is called before the first frame update
    void Start()
    {
        grabbable = this.transform.GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.grabbable.isGrabbed == true)
        {
            scalePanel.SetActive(true);
            this.gameObject.SetActive(false);
            this.grabbable.grabbedBy.gameObject.GetComponent<OVRGrabber>().ForceRelease(this.grabbable);
        }
    }
}
