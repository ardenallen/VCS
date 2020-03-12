using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabDetect : MonoBehaviour
{
    public bool isTrigered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
