using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObjects : MonoBehaviour
{
    public OVRGrabbable grabbable;

    public bool scale;
    // Start is called before the first frame update
    void Start()
    {
        grabbable = transform.GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

  
}
