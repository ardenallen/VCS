using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.PUN;
using Photon.Voice.Unity;

public class Mute : MonoBehaviour
{
    public Recorder rec;
    private bool enabled = false;

    // Start is called before the first frame update
    void Start()
    {
        //instructor = GameObject.FindGameObjectsWithTag("Instructor")[0].GetComponent<PhotonVoiceView>();
        //rec = instructor.GetComponent<Recorder>();  
    }

    // Update is called once per frame
    public void OnClick()
    {
        enabled = !enabled;
        if (enabled)
        {
            rec.IsRecording = false;
        }
        else
        {
            rec.IsRecording = true;
        }
    }
}
