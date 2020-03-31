/************************************************************************************
Filename    :   NetworkPlayer.cs
Content     :   Synchronize self position and rotatio, hands position and rotation, stethscope status to other users
************************************************************************************/

using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class NetworkPlayer : MonoBehaviourPun,IPunObservable
{
    private PhotonView pv;

    public GameObject LeftHand;
    public GameObject RightHand;
   
    public Transform playerGlobal;
    public Transform playerLocal;

    public Transform lefthandLocal; //left hand in the scene
    public Transform righthandLocal; //right hand in the scene

    public Text userName;

    public Stethoscope localSteControl;
    public GameObject StethoscopeOnHand; //local stethoscope on player's hand
    public GameObject StethoscopeTrigger; //local stethoscope on crashcart
    public bool isOnHand;

    public GameObject Stethoscope;

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

            localSteControl = GameObject.Find("TrainingManager").GetComponent<Stethoscope>();

            StethoscopeOnHand = localSteControl.StethoscopeOnHand;
            isOnHand = localSteControl.isUse;
            StethoscopeTrigger = localSteControl.StethoscopeTrigger;
        }

    }

    void Update()
    {
        if (isOnHand != localSteControl.isUse) //judge stethoscope is being used or not
        {
            if (localSteControl.isUse)
            {
                pv.RPC("RPC_StethoscopeInUse", RpcTarget.Others, StethoscopeTrigger.activeSelf);
            }
            else
            {
                pv.RPC("RPC_StethoscopeNotUse", RpcTarget.Others, StethoscopeTrigger.activeSelf, StethoscopeTrigger.transform.position);
            }

            isOnHand = localSteControl.isUse;
        }
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) //send and receive self position and rotation
    {
        if (stream.IsWriting)
        {
            stream.SendNext(playerGlobal.position);
            stream.SendNext(playerGlobal.rotation);

            stream.SendNext(playerGlobal.TransformPoint(lefthandLocal.position));
            stream.SendNext(lefthandLocal.rotation);

            stream.SendNext(playerGlobal.TransformPoint(righthandLocal.position));
            stream.SendNext(righthandLocal.rotation);
        }
        else
        {
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();

            LeftHand.transform.position = LeftHand.transform.parent.InverseTransformPoint((Vector3)stream.ReceiveNext());
            LeftHand.transform.rotation = (Quaternion)stream.ReceiveNext();

            RightHand.transform.position = RightHand.transform.parent.InverseTransformPoint((Vector3)stream.ReceiveNext());
            RightHand.transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }



    [PunRPC]
    public void RPC_Name(string name) //transfer own name to other users
    {
        userName.text = name;
    }

}
