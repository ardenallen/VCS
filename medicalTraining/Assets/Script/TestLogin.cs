using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class TestLogin : MonoBehaviourPunCallbacks
{
    public GameObject nameScreen;
    public GameObject roomScreen;

    public Text name;
    public Text code;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        nameScreen.SetActive(true);
    }

    public void NameButton()
    {
        PhotonNetwork.NickName = name.text;

        nameScreen.SetActive(false);
        roomScreen.SetActive(true);

    }

    public void RoomButton()
    {
        RoomOptions options = new RoomOptions { MaxPlayers = 3 };
        PhotonNetwork.JoinOrCreateRoom(code.text, options, default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }

}
