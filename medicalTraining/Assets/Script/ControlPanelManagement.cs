using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ControlPanelManagement : MonoBehaviour
{
    public GameObject lights;
    public GameObject turnOffLightBtn;
    public GameObject turnOnLightBtn;
    public bool lightStates;

    public VideoPlayer videoPlayer;
    public VideoClip hr76;
    public VideoClip hr125;

    public GameObject[] vitals;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.clip = hr76;

        if(!lights.activeInHierarchy)
        {
            lightStates = false;
        }
        else
        {
            lightStates = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //lights.SetActive(lightStates);
    }

    public void TurnOffLight()
    {
        lightStates = false;

        turnOffLightBtn.SetActive(false);
        turnOnLightBtn.SetActive(true);

    }

    public void TurnOnLight()
    {
        lightStates = true;

        turnOnLightBtn.SetActive(false);
        turnOffLightBtn.SetActive(true);

    }

    //public void FindObject(string objname)
    //{
    //    for(int i = 0; i < vitals.Length; i++)
    //    {

    //    }
    //}
}
