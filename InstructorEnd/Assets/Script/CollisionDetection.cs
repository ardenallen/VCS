using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("TrainingManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Stethoscope")
            audioSource.Play();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Stethoscope")
            audioSource.Stop();
    }
}
