/************************************************************************************
Filename    :   CollisionDetection.cs
Content     :   Detect the collision between breath area and stethoscope and play audio
************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private AudioSource audioSource;
    public bool isTriggered;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("TrainingManager").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Stethoscope")
        {
            audioSource.Play();
            isTriggered = true;
        }
            
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Stethoscope")
        {
            audioSource.Stop();
            isTriggered = false;
        }
    }
}
