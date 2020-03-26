using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ControlPanelDataTransfer : MonoBehaviourPun
{
    public PhotonView pv;
    public ControlPanelManagement controlPanelManagement;

    private string Vitalname;
    private string Vitalnumber;
    private string objName;
    private bool objState;
    private GameObject vitalmonitor;
    private GameObject changeables;
    private Animator patient;

    public GameObject StethoscopeTrigger;
    public GameObject Stethoscope;

    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();

        controlPanelManagement = GameObject.Find("TrainingManager").GetComponent<ControlPanelManagement>();
        vitalmonitor = GameObject.Find("VitalPanel/Panel/RawImage");
        changeables = GameObject.Find("TraumaBay/Changeables");
        patient = GameObject.Find("Characters/mannequin").GetComponent<Animator>();

        StethoscopeTrigger = GameObject.Find("stethoscope").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (controlPanelManagement.vis_changed)
        {
            objName = controlPanelManagement.objname;
            objState = controlPanelManagement.objvis;
            pv.RPC("RPC_ToggleVis", RpcTarget.AllBuffered, objName, objState);
            controlPanelManagement.vis_changed = false;
        }
        if (controlPanelManagement.update_vitals)
        {
            Vitalname = controlPanelManagement.vitalName;
            Vitalnumber = controlPanelManagement.vitalNumber;
            pv.RPC("RPC_VitalChange", RpcTarget.AllBuffered, Vitalname, Vitalnumber);
            controlPanelManagement.update_vitals = false;
        }
        if (controlPanelManagement.patientButton.pressed_changed)
        {
            pv.RPC("RPC_talking", RpcTarget.AllBuffered, controlPanelManagement.patientButton.talking);
            controlPanelManagement.patientButton.pressed_changed = false;
        }
        if (controlPanelManagement.volume_changed)
        {
            pv.RPC("RPC_Volume", RpcTarget.OthersBuffered, controlPanelManagement.volume);
            controlPanelManagement.volume_changed = false;
        }
    }

    [PunRPC]
    public void RPC_VitalChange(string obj, string numbers)
    {
        vitalmonitor.transform.Find(obj +"/Number").GetComponent<Text>().text = numbers;
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
    public void RPC_StethoscopeInUse(bool onHand, bool trigger)
    {
        Stethoscope.SetActive(onHand);
        StethoscopeTrigger.SetActive(trigger);
    }

    [PunRPC]
    public void RPC_StethoscopeNotUse(bool onHand, bool trigger, Vector3 pos)
    {
        Stethoscope.SetActive(onHand);
        StethoscopeTrigger.SetActive(trigger);
        GameObject.Find("stethoscope").transform.position = pos;
    }

}
