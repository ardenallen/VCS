using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkLauncher : MonoBehaviourPunCallbacks
{
    public GameObject welcomeScreen;
    public GameObject usernameScreen;
    public GameObject passcodeScreen;
    public GameObject roleScreen;
    public GameObject loadingScreen;

    public Text playerName;
    public Text[] roomNumber;
    public string charactor;

    public Slider progressBar;
    public Text progressPercentage;

    private string code;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Update()
    {
        if (welcomeScreen.activeInHierarchy == true)
        {
            if (Input.anyKeyDown)
            {
                welcomeScreen.SetActive(false);
                usernameScreen.SetActive(true);
            }
        }
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        welcomeScreen.SetActive(true);
    }

    public void NameButton()
    {
        PhotonNetwork.NickName = playerName.text;

        usernameScreen.SetActive(false);
        passcodeScreen.SetActive(true);


    }

    public void CodeButton()
    {
        string[] strg = new string[roomNumber.Length];
        for (int i = 0; i < roomNumber.Length; i++)
        {
            strg[i] = roomNumber[i].text;            
        }
        code = string.Concat(strg);


        passcodeScreen.SetActive(false);
        roleScreen.SetActive(true);
    }

    public void RoleSelectionButton()
    {
        IEnumerable<Toggle> toggleGroup = GameObject.Find("Canvas/Role/ToggleGroup").GetComponent<ToggleGroup>().ActiveToggles();
        foreach(Toggle t in toggleGroup)
        {
            if(t.isOn)
                switch (t.name)
                {
                    case "LeadDoctor":
                        charactor = "LeadDoctor";
                        break;
                    case "Doctor":
                        charactor = "Doctor";
                        break;
                }
            break;
        }

        roleScreen.SetActive(false);
        loadingScreen.SetActive(true);

        PhotonNetwork.AutomaticallySyncScene = true;
        StartCoroutine(LoadLevelAsync());
    }


    IEnumerator LoadLevelAsync()
    {
        PhotonNetwork.LoadLevel(1);

        RoomOptions options = new RoomOptions { MaxPlayers = 3 };
        PhotonNetwork.JoinOrCreateRoom(code, options, default);

        while (PhotonNetwork.LevelLoadingProgress < 1)
        {
            progressPercentage.text = "Loading..." + (int)(PhotonNetwork.LevelLoadingProgress * 100) + "%";
            //loadAmount = async.progress;
            progressBar.value = PhotonNetwork.LevelLoadingProgress;
            yield return new WaitForEndOfFrame();
        }
    }
}

    //public override void OnJoinedRoom()
    //{
    //    PhotonNetwork.LoadLevel(1);
    //}


    //public override void OnJoinedRoom()
    //{
    //    base.OnJoinedRoom();
    //    PhotonNetwork.Instantiate("Player", new Vector3(-4, 1, 0), Quaternion.identity, 0);
    //}