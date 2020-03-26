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

           

            LeftHand.SetActive(false);
            RightHand.SetActive(false);
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
    public void RPC_Name(string name)
    {
        userName.text = name;
    }
}
