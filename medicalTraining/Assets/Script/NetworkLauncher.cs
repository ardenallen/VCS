using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.Video;

public class NetworkLauncher : MonoBehaviourPunCallback
{
    public GameObject welcomeScreen;
    public GameObject usernameScreen;
    public GameObject passcodeScreen;
    public GameObject roleScreen;
    public GameObject instructionScreen;
    public GameObject startScreen;
    public GameObject loadingScreen;

    public Text playerName;
    public Text roomNumber;
    public string charactor;

    public Slider progressBar;
    public Text progressPercentage;

    public VideoPlayer ins;

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
            if (OVRInput.GetDown(OVRInput.Button.Any))
            {
                welcomeScreen.SetActive(false);
                usernameScreen.SetActive(true);
            }
        }
        if (instructionScreen.activeSelf)
        {
            Invoke("ShowStart", (float)ins.clip.length);
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
        //string[] strg = new string[roomNumber.Length];
        //for (int i = 0; i < roomNumber.Length; i++)
        //{
        //    strg[i] = roomNumber[i].text;            
        //}
        //code = string.Concat(strg);
        if (roomNumber.text.Length >= 3)
        {
            code = roomNumber.text;
            passcodeScreen.SetActive(false);
            roleScreen.SetActive(true);
        }
        
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
        instructionScreen.SetActive(true);
    }
    public void SkipButton()
    {
        instructionScreen.SetActive(false);
        loadingScreen.SetActive(true);

        RoomOptions options = new RoomOptions { MaxPlayers = 3 };
        PhotonNetwork.JoinOrCreateRoom(code, options, default);
        //PhotonNetwork.LoadLevel(1);
        //StartCoroutine(LoadLevelAsync());
    }
    public void StartTrainingButton()
    {
        loadingScreen.SetActive(true);

        RoomOptions options = new RoomOptions { MaxPlayers = 3 };
        PhotonNetwork.JoinOrCreateRoom(code, options, default);
        //PhotonNetwork.LoadLevel(1);
        //StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        //PhotonNetwork.LoadLevel(1);
        PhotonNetwork.IsMessageQueueRunning = false;
       // AsyncOperation async = PhotonNetwork.LoadLevelAsync;
        while (PhotonNetwork.LevelLoadingProgress < 1)
        {
            progressPercentage.text = "Loading..." + (int)(PhotonNetwork.LevelLoadingProgress * 100) + "%";
            //loadAmount = async.progress;
            progressBar.value = PhotonNetwork.LevelLoadingProgress;
            yield return new WaitForEndOfFrame();
        }
    }

    public void ShowStart()
    {
        startScreen.SetActive(true);
    }


    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public void BackToName()
    {
        usernameScreen.SetActive(true);
        passcodeScreen.SetActive(false);
    }

    public void BackToCode()
    {
        passcodeScreen.SetActive(true);
        roleScreen.SetActive(false);
    }

    public void BackToRole()
    {
        instructionScreen.SetActive(false);
        roleScreen.SetActive(true);
    }

    public void ReplayVideo()
    {
        instructionScreen.SetActive(true);
        startScreen.SetActive(false);
    }
}
