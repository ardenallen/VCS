using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PatientButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool pressed_changed;
    public bool talking;
    private Buttons button;
    //public Animator m_animator;
    void Start()
    {
        button = GetComponent<Buttons>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed_changed = true;
        talking = true;
        button.OnClick();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed_changed = true;
        talking = false;
        button.OnClick();
    }
}
