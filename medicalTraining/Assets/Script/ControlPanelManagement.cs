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

    public GameObject StethoscopeTrigger;
    public GameObject StethoscopeOnHand;

    public OVRGrabber rightHand;

    public GameObject placeHolder;

    public GameObject[] vitals;

    public GameObject iv_fluid;

    public GameObject senario;

    private bool breathStatus;
    private Vector3 posSte;
    
    // Start is called before the first frame update
    void Start()
    {
        //videoPlayer.clip = hr76;
        lightStates = lights.activeInHierarchy;
        posSte = StethoscopeTrigger.transform.position;
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

        if (StethoscopeTrigger.GetComponent<OVRGrabbable>().isGrabbed == true)
        {
            //StethoscopeTrigger.GetComponent<OVRGrabbable>().enabled = false;
            rightHand.ForceRelease(StethoscopeTrigger.GetComponent<OVRGrabbable>());

            StethoscopeTrigger.SetActive(false);
            StethoscopeOnHand.SetActive(true);
            Invoke("ShowPlaceHolder", 2);
        }
        if (placeHolder.GetComponent<ColliderDetect>().isTrigered == true)
        {
            StethoscopeOnHand.SetActive(false);
            StethoscopeTrigger.transform.position = posSte;
            StethoscopeTrigger.SetActive(true);
            placeHolder.SetActive(false);
        }

        if (senario.activeSelf == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                senario.SetActive(false);
            }
        }
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
    void ShowPlaceHolder()
    {
        placeHolder.SetActive(true);
    }
}