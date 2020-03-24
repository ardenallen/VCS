using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ActivePlayers : MonoBehaviourPun
{
    public Text _text;

    // Update is called once per frame
    void Update()
    {
        _text.text = PhotonNetwork.PlayerListOthers.Length.ToString();
    }
}
