using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkPlayer : MonoBehaviourPun, IPunObservable
{
    public GameObject avatar;
    public GameObject LeftHand;
    public GameObject RightHand;

    public Transform playerGlobal;
    public Transform playerLocal;

    public Transform lefthandLocal;
    public Transform righthandLocal;

    public GameObject StethoscopeTrigger;
    public GameObject Stethoscope;

    public Text userName;

    // Start is called before the first frame update
    void Start()
    {
        StethoscopeTrigger = GameObject.Find("stethoscope").gameObject;
       // userName.text = PhotonNetwork.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        userName.gameObject.transform.LookAt(GameObject.Find("InstructorCamera/Camera").transform.position);
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
        StethoscopeTrigger.SetActive(trigger);
        GameObject.Find("stethoscope").transform.position = pos;
    }

    [PunRPC]
    public void RPC_Name(string name)
    {
        userName.text = name;
    }
}
