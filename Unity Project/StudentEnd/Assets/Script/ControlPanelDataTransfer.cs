﻿/************************************************************************************
Filename    :   ControlPanelDataTransfer.cs
Content     :   Transfer and receive data from other users
************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ControlPanelDataTransfer : MonoBehaviourPun
{
    public PhotonView pv;
    public ControlPanelManagement controlPanelManagement;

    private GameObject vitalmonitor;

    private GameObject changeables;
    private Animator patient;

    public GameObject Xray_chest;
    public GameObject Xray_Plv;
    public GameObject Bloody_result;

    //is the game object scaled
    private bool Chest_Xray_scale; 
    private bool Plv_Xray_scale;
    private bool Bloody_Result_scale;



    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();

        controlPanelManagement = GameObject.Find("TrainingManager").GetComponent<ControlPanelManagement>();

        vitalmonitor = GameObject.Find("VitalPanel/Panel/RawImage");

        changeables = GameObject.Find("TraumaBay/Changeables");
        patient = GameObject.Find("Characters/mannequin").GetComponent<Animator>();

        Xray_chest = changeables.transform.Find("X-rayImage/XRay_Chest_Scale").gameObject;
        Xray_Plv = changeables.transform.Find("X-rayImage/XRay_Pelvis_Scale").gameObject;
        Bloody_result = changeables.transform.Find("Bloodwork/Bloodwork_Scale").gameObject;

        Chest_Xray_scale = Xray_chest.activeSelf;
        Plv_Xray_scale = Xray_Plv.activeSelf;
        Bloody_Result_scale = Bloody_result.activeSelf;
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
            
    }

    //For send and or receive data through other users
    [PunRPC]
    public void RPC_VitalChange(string obj, string numbers) //Change vital numbers
    {
        if (vitalmonitor)
        {
            vitalmonitor.transform.Find(obj + "/Number").GetComponent<Text>().text = numbers;
        }
    }
    [PunRPC]
    public void RPC_ToggleVis(string obj, bool val) //Active tools
    {
        GameObject o = changeables.transform.Find(obj).gameObject;
        o.SetActive(val);
    }

    [PunRPC]
    public void RPC_talking(bool talking) //Active patient talking animation
    {
        patient.SetBool("isSpeaking", talking);
    }

    [PunRPC]
    public void RPC_ScaleObj(string obj, bool scale) //Active scaled objects
    {
        changeables.transform.Find(obj).gameObject.SetActive(scale);
    }

    [PunRPC]
    public void RPC_Volume(float vol) //Adujust chatting volume
    {
        GameObject.Find("Instructor(Clone)").GetComponent<AudioSource>().volume = vol;
    }

    
}