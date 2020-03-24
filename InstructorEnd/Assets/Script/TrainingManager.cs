using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TrainingManager : MonoBehaviourPun
{

    void Start()
    {

        if (PhotonNetwork.NickName == "stu1")
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
