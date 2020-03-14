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

    public GameObject breathArea;

    public GameObject StethoscopePrefab;
    public GameObject StethoscopeTrigger;
    public GameObject StethoscopeOnHand;

    public OVRGrabber rightHand;

    public GameObject placeHolder;

    public GameObject[] vitals;

    public GameObject iv_fluid;

    public GameObject senario;

    private bool breathStatus;
    private Vector3 posSte;

    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.clip = hr76;
        //lightStates = lights.activeInHierarchy;
        posSte = StethoscopeTrigger.transform.position;

        for(int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //lights.SetActive(lightStates);

        breathStatus = breathArea.GetComponent<CollisionDetection>().isTriggered;
        if (breathStatus == false)
        {
            StethoscopeOnHand.transform.localPosition = Vector3.zero;
        }

        //if (StethoscopeTrigger.GetComponent<GrabDetect>().isTrigered == true && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) &&
        //    OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        //{
        //    StethoscopeTrigger.GetComponent<GrabDetect>().isTrigered = false;
        //    StethoscopeTrigger.SetActive(false);
        //    StethoscopeOnHand.SetActive(true);
        //    Debug.Log(1);
        //}
        //else if (StethoscopeTrigger.GetComponent<GrabDetect>().isTrigered == false && OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        //{
        //    Debug.Log(2);
        //    StethoscopeTrigger.transform.position = rightHand.transform.position;
        //    StethoscopeTrigger.SetActive(true);
        //    StethoscopeOnHand.SetActive(false);
        //}
        if (StethoscopeTrigger.GetComponent<OVRGrabbable>().isGrabbed == true)
        {
            StethoscopeTrigger.SetActive(false);
            StethoscopeOnHand.SetActive(true);
            rightHand.ForceRelease(StethoscopeTrigger.GetComponent<OVRGrabbable>());
            Invoke("ShowPlaceHolder", 2);
        }
        //if (StethoscopeTrigger.activeSelf == false && OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
        //{
        //    Debug.Log(1);
        //    Destroy(StethoscopeTrigger);
        //    StethoscopeTrigger = Instantiate(StethoscopePrefab, rightHand.transform, true);
        //    StethoscopeOnHand.SetActive(false);
        //}
        if (placeHolder.GetComponent<ColliderDetect>().isTriggered == true)
        {
            StethoscopeOnHand.SetActive(false);
            StethoscopeTrigger.transform.position = posSte;
            StethoscopeTrigger.SetActive(true);
            placeHolder.SetActive(false);
        }

        if (senario.activeSelf == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.Any))
            {
                senario.SetActive(false);
            }
        }
    } 


//public void TurnOffLight()
//{
//    lightStates = false;

//    turnOffLightBtn.SetActive(false);
//    turnOnLightBtn.SetActive(true);

//}

//public void TurnOnLight()
//{
//    lightStates = true;

//    turnOnLightBtn.SetActive(false);
//    turnOffLightBtn.SetActive(true);

//}
    void ShowPlaceHolder()
    {
        placeHolder.SetActive(true);
    }
}