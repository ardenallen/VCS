using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TrainingManager : MonoBehaviourPun
{

    void Start()
    {

         PhotonNetwork.Instantiate("Instructor", new Vector3(0, 0, 0), Quaternion.identity, 0);


    }

    void Update()
    {

    }

   

   
}
