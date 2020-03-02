<<<<<<< Updated upstream
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TrainingManager : MonoBehaviourPun
{
    //public GameObject readyButton;
    //public GameObject Students_FP;
    //public GameObject Students_TP;
    //public GameObject Instructor;



    //public void ReadyToPlay()
    //{
    //    readyButton.SetActive(false);
    //    PhotonNetwork.Instantiate("Player", new Vector3(-4, 1, 0), Quaternion.identity, 0);
    //}

    void Start()
    {
        //if (PhotonNetwork.NickName == "Student1")
        //{
        //    PhotonNetwork.Instantiate("NetworkPlayer", new Vector3(-4, 1, 0), Quaternion.identity, 0);
        //}

        //if (PhotonNetwork.NickName == "Instructor")
        //{
        //    PhotonNetwork.Instantiate(Instructor.name, new Vector3(0, 0, 0), Quaternion.identity, 0);
        //}

        if (PhotonNetwork.NickName == "Student1")
        {
            PhotonNetwork.Instantiate("NetworkPlayer", new Vector3(-4, 1, 0), Quaternion.identity, 0);
        }
        else
            PhotonNetwork.Instantiate("Instructor", new Vector3(0, 0, 0), Quaternion.identity, 0);


    }

    void Update()
    {

    }

   

   
}
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TrainingManager : MonoBehaviourPun
{
    //public GameObject readyButton;
    //public GameObject Students_FP;
    //public GameObject Students_TP;
    //public GameObject Instructor;



    //public void ReadyToPlay()
    //{
    //    readyButton.SetActive(false);
    //    PhotonNetwork.Instantiate("Player", new Vector3(-4, 1, 0), Quaternion.identity, 0);
    //}

    void Start()
    {
        //if (PhotonNetwork.NickName == "Student1")
        //{
        //    PhotonNetwork.Instantiate("NetworkPlayer", new Vector3(-4, 1, 0), Quaternion.identity, 0);
        //}

        //if (PhotonNetwork.NickName == "Instructor")
        //{
        //    PhotonNetwork.Instantiate(Instructor.name, new Vector3(0, 0, 0), Quaternion.identity, 0);
        //}

       
        
            PhotonNetwork.Instantiate("NetworkPlayer", new Vector3(-4, 1, 0), Quaternion.identity, 0);
      


    }

    void Update()
    {

    }

   

   
}
>>>>>>> Stashed changes
