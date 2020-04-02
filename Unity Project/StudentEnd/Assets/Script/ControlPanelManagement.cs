/************************************************************************************
Filename    :   ControlPanelManagement.cs
Content     :   Save animations and organize tools
************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class ControlPanelManagement : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip hr76;
    public VideoClip hr125;

    public GameObject senario;

    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.clip = hr76; //active animation

        for (int i = 0; i < items.Length; i++) //Hide tools
        {
            items[i].SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (senario.activeSelf == true) //close senatio description panel
        {
            if (OVRInput.GetDown(OVRInput.Button.Any))
            {
                senario.SetActive(false);
            }
        }

    }

}