using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.Video;

public class ControlPanelDataTransfer : MonoBehaviourPun
{
    public PhotonView pv;
    public ControlPanelManagement controlPanelManagement;

    private string Vitalname;
    private string Vitalnumber;
    private GameObject vitalmonitor;

    private GameObject changeables;
    private Animator patient;

    public GameObject Xray_chest;
    public GameObject Xray_Plv;
    public GameObject Bloody_result;

    private bool Chest_Xray_scale;
    private bool Plv_Xray_scale;
    private bool Bloody_Result_scale;

    public Stethoscope localSteControl;
    public GameObject StethoscopeOnHand;
    public GameObject StethoscopeTrigger;
    public bool isOnHand;

    public GameObject Stethoscope;

    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();

        controlPanelManagement = GameObject.Find("TrainingManager").GetComponent<ControlPanelManagement>();
        localSteControl = GameObject.Find("TrainingManager").GetComponent<Stethoscope>();

        vitalmonitor = GameObject.Find("VitalPanel/Panel/RawImage");

        changeables = GameObject.Find("TraumaBay/Changeables");
        patient = GameObject.Find("Characters/mannequin").GetComponent<Animator>();

        Xray_chest = changeables.transform.Find("X-rayImage/XRay_Chest_Scale").gameObject;
        Xray_Plv = changeables.transform.Find("X-rayImage/XRay_Pelvis_Scale").gameObject;
        Bloody_result = changeables.transform.Find("Bloodwork/Bloodwork_Scale").gameObject;

        Chest_Xray_scale = Xray_chest.activeSelf;
        Plv_Xray_scale = Xray_Plv.activeSelf;
        Bloody_Result_scale = Bloody_result.activeSelf;

        StethoscopeOnHand = localSteControl.StethoscopeOnHand;
        isOnHand = StethoscopeOnHand.activeSelf;
        StethoscopeTrigger = localSteControl.StethoscopeTrigger;

    }

    void Update()
    {
        if (Chest_Xray_scale != Xray_chest.activeSelf)
        {
            Chest_Xray_scale = Xray_chest.activeSelf;
            pv.RPC("RPC_ScaleObj", RpcTarget.All, "X-rayImage/" + Xray_chest.name, Chest_Xray_scale);
        }

        if (Plv_Xray_scale != Xray_Plv.activeSelf)
        {
            Plv_Xray_scale = Xray_Plv.activeSelf;
            pv.RPC("RPC_ScaleObj", RpcTarget.All, "X-rayImage/" + Xray_Plv.name, Plv_Xray_scale);
        }

        if (Bloody_Result_scale != Bloody_result.activeSelf)
        {
            Bloody_Result_scale = Bloody_result.activeSelf;
            pv.RPC("RPC_ScaleObj", RpcTarget.All, "Bloodwork/" + Bloody_result.name, Bloody_Result_scale);
        }

        if (StethoscopeOnHand.activeSelf != isOnHand)
        {
            if (StethoscopeTrigger.activeSelf == false)
            {
                pv.RPC("RPC_StethoscopeInUse", RpcTarget.Others, isOnHand, StethoscopeTrigger.activeSelf);
                isOnHand = StethoscopeOnHand.activeSelf;
            }
            else if(StethoscopeTrigger.activeSelf == true)
            {
                pv.RPC("RPC_StethoscopeNotUse", RpcTarget.Others, isOnHand, StethoscopeTrigger.activeSelf);
                isOnHand = StethoscopeOnHand.activeSelf;
            }
        }
            
            
    }

    [PunRPC]
    public void RPC_VitalChange(string obj, string numbers)
    {
        if (vitalmonitor)
        {
            vitalmonitor.transform.Find(obj + "/Number").GetComponent<Text>().text = numbers;
        }
    }
    [PunRPC]
    public void RPC_ToggleVis(string obj, bool val)
    {
        GameObject o = changeables.transform.Find(obj).gameObject;
        o.SetActive(val);
    }

    [PunRPC]
    public void RPC_talking(bool talking)
    {
        patient.SetBool("isSpeaking", talking);
    }

    [PunRPC]
    public void RPC_ScaleObj(string obj, bool scale)
    {
        changeables.transform.Find(obj).gameObject.SetActive(scale);
    }

    [PunRPC]
    public void RPC_Volume(float vol)
    {
        GameObject.Find("Instructor(Clone)").GetComponent<AudioSource>().volume = vol;
    }

    [PunRPC]
    public void RPC_StethoscopeInUse(bool onHand, bool trigger)
    {
        Stethoscope.SetActive(onHand);
        StethoscopeTrigger.SetActive(trigger);
    }

    [PunRPC]
    public void RPC_StethoscopeNotUse(bool onHand, bool trigger, Vector3 pos)
    {
        Stethoscope.SetActive(onHand);
        GameObject.Find("stethoscope").gameObject.SetActive(trigger);
        GameObject.Find("stethoscope").transform.position = pos;
    }
}
