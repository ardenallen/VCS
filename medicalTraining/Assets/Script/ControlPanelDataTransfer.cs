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

    private bool _lightState;
    private string Vitalname;
    private string Vitalnumber;
    private GameObject vitalmonitor;

    private GameObject changeables;
    private Animator patient;



    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();

        controlPanelManagement = GameObject.Find("TrainingManager").GetComponent<ControlPanelManagement>();

        vitalmonitor = GameObject.Find("VitalPanel/Panel/RawImage");

        changeables = GameObject.Find("TraumaBay/Changeables");
        patient = GameObject.Find("Characters/mannequin").GetComponent<Animator>();
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
    public void RPC_ObjSync(string obj, Vector3 pos, Quaternion rot)
    {
        Transform go = changeables.transform.Find(obj);
        go.position = pos;
        go.rotation = rot;
    }

    [PunRPC]
    public void RPC_talking(bool talking)
    {
        patient.SetBool("isSpeaking", talking);
    }
}
