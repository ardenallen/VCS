using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    public GameObject nameUI;
    public GameObject roomUI;
    //public InputField playerName;
    //public InputField roomName;
    public Text playerName;
    public Text roomNumber;
    
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        nameUI.SetActive(true);

       // PhotonNetwork.JoinOrCreateRoom("TrainingRoom", new Photon.Realtime.RoomOptions() { MaxPlayers=3 },default);

    }

    public void nameButton()
    {
        PhotonNetwork.NickName = playerName.text;
        nameUI.SetActive(false);
        roomUI.SetActive(true);
    }

    public void roomButton()
    {
        if (roomNumber.text.Length < 3)
            return;

        roomUI.SetActive(false);

        RoomOptions options = new RoomOptions { MaxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom(roomNumber.text, options, default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }


    //public override void OnJoinedRoom()
    //{
    //    base.OnJoinedRoom();
    //    PhotonNetwork.Instantiate("Player", new Vector3(-4, 1, 0), Quaternion.identity, 0);
    //}
}
