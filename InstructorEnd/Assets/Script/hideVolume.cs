using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class hideVolume : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool MouseOver;
    public Button volume;

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseOver = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !MouseOver && volume.GetComponent<volumeButton>().clicked)
        {
            volume.onClick.Invoke();
        }
    }


}
