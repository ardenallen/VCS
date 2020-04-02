/************************************************************************************
Filename    :   CharacterInfo.cs
Content     :   For transfering user role selection information to next scene
************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public string character; //role selection info (Lead doc / Doc)
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
