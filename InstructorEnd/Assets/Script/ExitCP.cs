using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Voice.PUN;

public class ExitCP : MonoBehaviourPunCallbacks
{
    public void exit()
    {
        PhotonNetwork.LoadLevel(0);
        PhotonNetwork.LeaveRoom();
        GameObject.Find("Voice").GetComponent<PhotonVoiceNetwork>().Disconnect();
    }

    //public override void OnLeftRoom()
    //{
    //    Debug.Log("LEFT ROOM");
    //}
}
