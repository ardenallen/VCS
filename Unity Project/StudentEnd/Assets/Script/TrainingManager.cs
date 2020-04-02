/************************************************************************************
Filename    :   TrainingManager.cs
Content     :   Instantiate player prefab after the scene loaded
************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TrainingManager : MonoBehaviourPun
{
    public GameObject characterType; //Lead doc or Doc
    void Start()
    {
        characterType = GameObject.Find("CharacterInfo");

        PhotonNetwork.Instantiate(characterType.GetComponent<CharacterInfo>().character, new Vector3(-4, 1, 0), Quaternion.identity, 0); //instaniate player

        Destroy(characterType);

    }


   

   
}
