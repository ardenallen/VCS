using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    public Text playerName;
    public Text roomNumber;
    public GameObject Login;
    public GameObject Dashboard;
    
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
        Login.SetActive(true);
        Dashboard.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
    }

    public void login()
    {
        PhotonNetwork.NickName = playerName.text;
        Dashboard.SetActive(true);
        Login.SetActive(false);
    }

    public void startSession()
    {
        if (roomNumber.text.Length < 3)
            return;

        RoomOptions options = new RoomOptions { MaxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom(roomNumber.text, options, default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
