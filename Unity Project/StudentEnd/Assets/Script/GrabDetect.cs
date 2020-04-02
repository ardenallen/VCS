/************************************************************************************
Filename    :   GrabDetection.cs
Content     :   Detect collision between right hand and stethoscope on crashcart
************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDetect : MonoBehaviour
{
    public bool isTrigered;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name== "CustomHandRight")
        {
            isTrigered = true;
;        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name== "CustomHandRight")
        {
            isTrigered = false;
;
        }
    }
}
