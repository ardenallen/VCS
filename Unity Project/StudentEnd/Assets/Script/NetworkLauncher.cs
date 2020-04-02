/************************************************************************************
Filename    :   NetworkLauncher.cs
Content     :   Control login UI, keyboard, and room creation or joining
************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.Video;

namespace TalesFromTheRift {
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
    
        public CharacterInfo character;

        public Slider progressBar;
        public Text progressPercentage;

        public VideoPlayer ins; //video player for hand instruction

        private string code;

        private GameObject keyboard;

        // Start is called before the first frame update
        void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.AutomaticallySyncScene = true;
 
            keyboard = GameObject.Find("Keyboard");
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

            if (instructionScreen.activeSelf == true)
            {
                StartCoroutine("ShowStartScreen");
            }

            if (usernameScreen.activeSelf) //auto active keyboard
            {
                GameObject iF = usernameScreen.transform.Find("InputField").gameObject;
                iF.GetComponent<InputField>().ActivateInputField();
                keyboard.GetComponent<OpenCanvasKeyboard>().inputObject = iF;
             }

            if (passcodeScreen.activeSelf) //auto active keyboard
            {
                GameObject iF = passcodeScreen.transform.Find("InputField").gameObject;
                iF.GetComponent<InputField>().ActivateInputField();
                keyboard.GetComponent<OpenCanvasKeyboard>().inputObject = iF;

            }

            if (roleScreen.activeSelf)
            {
                CanvasKeyboard.Close();
            }
         }

        public override void OnConnectedToMaster() //connect to server
        {
            base.OnConnectedToMaster();
            welcomeScreen.SetActive(true);
        }

        public void NameButton() //get user's name
        {
            if (playerName.text.Length >= 3)
            {
                PhotonNetwork.NickName = playerName.text;

                usernameScreen.SetActive(false);
                passcodeScreen.SetActive(true);
            }
    }

        public void CodeButton() //get room name
        {
            if (roomNumber.text.Length >= 3)
            {
                code = roomNumber.text;
                passcodeScreen.SetActive(false);
                roleScreen.SetActive(true);
            }
        
        }

        public void RoleSelectionButton() //get characters
        {
            IEnumerable<Toggle> toggleGroup = GameObject.Find("Canvas/Role/ToggleGroup").GetComponent<ToggleGroup>().ActiveToggles();
            foreach(Toggle t in toggleGroup)
            {
                if(t.isOn)
                     switch (t.name)
                    {
                        case "LeadDoctor":
                            character.character = "LeadDoctor";
                            break;
                        case "Doctor":
                            character.character = "Doctor";
                            break;
                    }
                     break;
            }

            roleScreen.SetActive(false);
            instructionScreen.SetActive(true);
        }
        public void SkipButton() //skip hand instruction
        {
            instructionScreen.SetActive(false);
            loadingScreen.SetActive(true);

            RoomOptions options = new RoomOptions { MaxPlayers = 3 };
            PhotonNetwork.JoinOrCreateRoom(code, options, default);

        }
        public void StartTrainingButton() //load next level
        {
            loadingScreen.SetActive(true);

            RoomOptions options = new RoomOptions { MaxPlayers = 3 };
            PhotonNetwork.JoinOrCreateRoom(code, options, default);
        
        }

        IEnumerator LoadLevelAsync() //progress bar
        {
            while (PhotonNetwork.LevelLoadingProgress < 1)
            {
                progressPercentage.text = "Loading..." + (int)(PhotonNetwork.LevelLoadingProgress * 100) + "%";
                progressBar.value = PhotonNetwork.LevelLoadingProgress;
                yield return new WaitForEndOfFrame();
            }
        }

        IEnumerator ShowStartScreen()
        {
            yield return new WaitForSeconds((float)ins.clip.length);
            instructionScreen.SetActive(false);
            startScreen.SetActive(true);
            StopCoroutine("ShowStartScreen");
        }


        public override void OnJoinedRoom()
        {
            PhotonNetwork.LoadLevel(1);
            StartCoroutine(LoadLevelAsync());
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
}
