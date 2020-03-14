using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Photon.Pun;

public class ControlPanelManagement : MonoBehaviour
{
    public GameObject lights;
    public GameObject turnOffLightBtn;
    public GameObject turnOnLightBtn;
    public bool lightStates;

    public VideoPlayer videoPlayer;
    public VideoClip hr76;
    public VideoClip hr125;

    public GameObject changePopup;

    public Text category;
    public Text oldFigure;
    public Text newFigure;
    public Button confirmChange;

    public GameObject[] vitalMode;
    public GameObject[] sliders;
    public GameObject[] bodyVitalMode;

    public string vitalName;
    public string vitalNumber;

    public bool vis_changed;

    public string objname;
    public bool objvis;

    
    

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.clip = hr76;

        changePopup.SetActive(false);

        for (int i = 0; i < vitalMode.Length; i++)
        {
            AddTriggersListener(vitalMode[i], EventTriggerType.PointerDown, OnPointerDown);
        }

        for (int i = 0; i < sliders.Length; i++)
        {
            AddTriggersListener(sliders[i], EventTriggerType.PointerDown, UpdateValue);
        }

        lightStates = lights.activeInHierarchy;
    }

    public void TurnOffLight()
    {
        lightStates = false;

        turnOffLightBtn.SetActive(false);
        turnOnLightBtn.SetActive(true);

    }

    public void TurnOnLight()
    {
        lightStates = true;

        turnOnLightBtn.SetActive(false);
        turnOffLightBtn.SetActive(true);

    }
    private void AddTriggersListener(GameObject _gameObject, EventTriggerType _event, UnityAction<BaseEventData> _action)
    {


        EventTrigger _trigger = _gameObject.GetComponent<EventTrigger>();
        if (_trigger == null)
        {
            _trigger = _gameObject.AddComponent<EventTrigger>();
            _trigger.triggers = new List<EventTrigger.Entry>();
        }

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = _event;

        entry.callback = new EventTrigger.TriggerEvent();
        UnityAction<BaseEventData> callback = new UnityAction<BaseEventData>(_action);
        entry.callback.AddListener(callback);
        _trigger.triggers.Add(entry);
    }

    private void OnPointerDown(BaseEventData eventData)
    {
        changePopup.SetActive(true);

        GameObject obj = EventSystem.current.currentSelectedGameObject;

        category.text = "Change" + obj.name;
        vitalName = obj.name;

        oldFigure.text = obj.transform.Find("Number").GetComponent<Text>().text;

        confirmChange.onClick.AddListener(
            delegate ()
           {
               if (obj.name == vitalName)
               {
                   obj.transform.Find("Number").GetComponent<Text>().text = newFigure.text;
                   vitalNumber = newFigure.text;
               }

               changePopup.SetActive(false);
           }
       );
    }

    private void UpdateValue(BaseEventData eventData)
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        objname = obj.transform.parent.name;
        if (obj.GetComponent<Slider>().value == 0)
        {
            obj.GetComponent<Slider>().value = 1;
            objvis = true;
        }
        else
        {
            obj.GetComponent<Slider>().value = 0;
            objvis = false;
        }
        vis_changed = true;
    }
}

