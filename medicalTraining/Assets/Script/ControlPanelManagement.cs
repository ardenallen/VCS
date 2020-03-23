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

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.clip = hr76;

        //for (int i = 0; i < items.Length; i++)
        //{
        //    items[i].SetActive(false);
        //}

    }

    // Update is called once per frame
    void Update()
    {
        if (senario.activeSelf == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.Any))
            {
                senario.SetActive(false);
            }
        }

    }

}