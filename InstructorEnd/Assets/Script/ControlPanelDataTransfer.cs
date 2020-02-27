using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ControlPanelDataTransfer : MonoBehaviourPun
{
    public PhotonView pv;
    public ControlPanelManagement controlPanelManagement;

    private bool _lightState;
    private string Vitalname;
    private string Vitalnumber;

    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();

        controlPanelManagement = GameObject.Find("TrainingManager").GetComponent<ControlPanelManagement>();

        Vitalname = controlPanelManagement.vitalName;
        Vitalnumber = controlPanelManagement.vitalNumber;

        //_lightState = controlPanelManagement.lightStates;

    }

    // Update is called once per frame
    void Update()
    {
        //for(int i = 0; i < controlPanelManagement.vitalMode.Length; i++)
        //{
        //    //GameObject obj = controlPanelManagement.vitalMode[i];
        //    //Debug.Log(obj.name);
        //    //if(vitals[i].text == controlPanelManagement.vitalMode[i].transform.Find("Number").GetComponent<Text>().text)
        //    //if (vitals[i].text!= obj.transform.Find("Number").GetComponent<Text>().text)
        //    {
        //        //vitals[i].text = controlPanelManagement.vitalMode[i].transform.Find("Text").transform.GetComponent<Text>().text;
        //        //pv.RPC("RPC_VitalChange", RpcTarget.Others, controlPanelManagement.vitalMode[i].name, vitals[i].text);
        //    }
        //}
        if (_lightState != controlPanelManagement.lightStates)
        {
            pv.RPC("RPC_LightSwitch", RpcTarget.All, controlPanelManagement.lightStates);
            _lightState = controlPanelManagement.lightStates;
        }
        if (Vitalname != controlPanelManagement.vitalName || Vitalnumber != controlPanelManagement.vitalNumber)
        {
            Vitalname = controlPanelManagement.vitalName;
            Vitalnumber = controlPanelManagement.vitalNumber;
            pv.RPC("RPC_VitalChange", RpcTarget.All, Vitalname, Vitalnumber);
        }
    }

    [PunRPC]
    public void RPC_LightSwitch(bool lightStates)
    {
        controlPanelManagement.lights.SetActive(lightStates);
        Debug.Log(lightStates);
    }
    public void RPC_VitalChange(string obj, string numbers)
    {
        //GameObject go = GameObject.Find("Canvas");
        GameObject.Find("Canvas").transform.Find("Panel/" + obj + "/Number").GetComponent<Text>().text = numbers;
    }



}
