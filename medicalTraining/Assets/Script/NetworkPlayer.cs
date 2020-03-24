using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkPlayer : MonoBehaviourPun,IPunObservable
{
    private PhotonView pv;

    public GameObject avatar;
    public GameObject LeftHand;
    public GameObject RightHand;
   
    public Transform playerGlobal;
    public Transform playerLocal;

    public Transform lefthandLocal;
    public Transform righthandLocal;

    public GameObject StethoscopeOnHand;
    public GameObject StethoscopeTrigger;
    public bool isOnHand;

    public GameObject Stethoscope;

    public Text userName;

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            pv = GetComponent<PhotonView>();

            userName.text = PhotonNetwork.NickName;
            pv.RPC("RPC_Name", RpcTarget.Others, userName.text);

            playerGlobal = GameObject.Find("OVRPlayerController").transform;
            playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor").transform;

            lefthandLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/LeftHandAnchor").transform;
            righthandLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/RightHandAnchor").transform;

            transform.SetParent(playerLocal);
            transform.localPosition = Vector3.zero;

            StethoscopeOnHand = playerGlobal.Find("OVRCameraRig/TrackingSpace/RightHandAnchor/RightControllerAnchor/Stethoscope").transform.gameObject;
            isOnHand = StethoscopeOnHand.activeSelf;
            StethoscopeTrigger = GameObject.Find("stethoscope").gameObject;

            LeftHand.SetActive(false);
            RightHand.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (StethoscopeOnHand.activeSelf !=isOnHand && StethoscopeTrigger.activeSelf == false)
        {
            isOnHand = StethoscopeOnHand.activeSelf;
            pv.RPC("RPC_StethoscopeInUse", RpcTarget.Others, isOnHand, StethoscopeTrigger.activeSelf);           
        }

        if(StethoscopeOnHand.activeSelf != isOnHand)
        {
            isOnHand = StethoscopeOnHand.activeSelf;
            pv.RPC("RPC_StethoscopeNotUse", RpcTarget.Others, isOnHand, StethoscopeTrigger.activeSelf, StethoscopeTrigger.transform.position);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(playerGlobal.position);
            stream.SendNext(playerGlobal.rotation);
            //stream.SendNext(playerLocal.position);
            //stream.SendNext(playerLocal.rotation);

            stream.SendNext(playerGlobal.TransformPoint(lefthandLocal.position));
            stream.SendNext(lefthandLocal.localRotation);

            stream.SendNext(playerGlobal.TransformPoint(righthandLocal.position));
            stream.SendNext(righthandLocal.localRotation);
        }
        else
        {
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
            //avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
            //avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();

            LeftHand.transform.position = LeftHand.transform.parent.InverseTransformPoint((Vector3)stream.ReceiveNext());
            LeftHand.transform.localRotation = (Quaternion)stream.ReceiveNext();

            RightHand.transform.position = RightHand.transform.parent.InverseTransformPoint((Vector3)stream.ReceiveNext());
            RightHand.transform.localRotation = (Quaternion)stream.ReceiveNext();


        }
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

    [PunRPC]
    public void RPC_Name(string name)
    {
        userName.text = name;
    }
}
