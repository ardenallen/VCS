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

        _lightState = controlPanelManagement.lightStates;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(_lightState != controlPanelManagement.lightStates)
        {
            pv.RPC("RPC_LightSwitch", RpcTarget.All, controlPanelManagement.lightStates);
            _lightState = controlPanelManagement.lightStates;
        }

    }

    [PunRPC]
    public void RPC_LightSwitch(bool lightStates)
    {
        controlPanelManagement.lights.SetActive(lightStates);
        Debug.Log(lightStates);
    }
    [PunRPC]
    public void RPC_VitalChange(string obj, string numbers)
    {
        GameObject.Find("Canvas/Panel/HR/Number").GetComponent<Text>().text = numbers;
    }



}
