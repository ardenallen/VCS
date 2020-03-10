using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkPlayer : MonoBehaviourPun,IPunObservable
{
    public GameObject avatar;
    public Transform playerGlobal;
    public Transform playerLocal;

    private PhotonView _pv;

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            playerGlobal = GameObject.Find("OVRPlayerController").transform;
            playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor").transform;

            transform.SetParent(playerLocal);
            transform.localPosition = Vector3.zero;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(playerGlobal.position);
            stream.SendNext(playerGlobal.rotation);
            stream.SendNext(playerLocal.position);
            stream.SendNext(playerLocal.rotation);
        }
        else
        {
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
            avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
            avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();

        }
    }
}
