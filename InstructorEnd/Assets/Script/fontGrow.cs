using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class fontGrow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = transform.Find("Number").GetComponent<Text>(); 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _text.fontSize += 10;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _text.fontSize -= 10;
    }
}
