using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TrainingManager : MonoBehaviourPun
{
    public GameObject characterType;
    void Start()
    {
        characterType = GameObject.Find("CharacterInfo");

        PhotonNetwork.Instantiate(characterType.GetComponent<CharacterInfo>().character, new Vector3(-4, 1, 0), Quaternion.identity, 0);

        Destroy(characterType);

    }

    void Update()
    {

    }

   

   
}
