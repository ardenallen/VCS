using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PatientTalking : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool pressed;

    public void Update()
    {
        if (!pressed)
            return;
        // DO SOMETHING HERE
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
}
