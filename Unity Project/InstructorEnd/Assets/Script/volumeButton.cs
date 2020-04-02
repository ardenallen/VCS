using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class volumeButton : MonoBehaviour
{
    public GameObject slider;
    public bool clicked = false;


    public void toggleVis()
    {
        clicked = !clicked;
        slider.SetActive(clicked);
    }
}
