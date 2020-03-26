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

    public Text userName;

    public GameObject StethoscopeTrigger;
    public GameObject StethoscopePrefab;

    private GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        StethoscopeTrigger = GameObject.Find("stethoscope").gameObject;
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
            //stream.SendNext(playerLocal.position);
            //stream.SendNext(playerLocal.rotation);

            stream.SendNext(playerGlobal.TransformPoint(lefthandLocal.position));
            stream.SendNext(lefthandLocal.rotation);

            stream.SendNext(playerGlobal.TransformPoint(righthandLocal.position));
            stream.SendNext(righthandLocal.rotation);
        }
        else
        {
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
            //avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
            //avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();

            LeftHand.transform.position = LeftHand.transform.parent.InverseTransformPoint((Vector3)stream.ReceiveNext());
            LeftHand.transform.rotation = (Quaternion)stream.ReceiveNext();

            RightHand.transform.position = RightHand.transform.parent.InverseTransformPoint((Vector3)stream.ReceiveNext());
            RightHand.transform.rotation = (Quaternion)stream.ReceiveNext();


        }
    }


    [PunRPC]
    public void RPC_Name(string name)
    {
        userName.text = name;
    }

    [PunRPC]
    public void RPC_StethoscopeInUse(bool trigger)
    {
        go = Instantiate(StethoscopePrefab, transform.Find("Righthand"));
        StethoscopeTrigger.SetActive(trigger);
    }

    [PunRPC]
    public void RPC_StethoscopeNotUse(bool trigger, Vector3 pos)
    {
        Destroy(go);
        StethoscopeTrigger.SetActive(trigger);
        StethoscopeTrigger.transform.position = pos;
    }
}
