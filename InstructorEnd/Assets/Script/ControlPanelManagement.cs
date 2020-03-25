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
    public VideoPlayer videoPlayer;
    public VideoClip hr76;
    public VideoClip hr125;

    public GameObject changePopup;

    public Text category;
    public InputField input;
    public Text oldFigure;
    public Button confirmChange;

    public GameObject[] vitalMode;
    public GameObject[] sliders;
    public GameObject[] bodyVitalMode;

    public string vitalName;
    public string vitalNumber;

    public PatientButton patientButton;
    public bool vis_changed;
    public bool update_vitals;

    public string objname;
    public bool objvis;
    private Color col = new Color(1.0f, 1.0f, 1.0f, 0.3529412f);
    private string oldNumber;

    public float volume;
    public bool volume_changed;
    public Slider vol;

    // Start is called before the first frame update
    void Start()
    {
        changePopup.SetActive(false);

        for (int i = 0; i < vitalMode.Length; i++)
        {
            AddTriggersListener(vitalMode[i], EventTriggerType.PointerDown, OnPointerDown);
        }

        for (int i = 0; i < sliders.Length; i++)
        {
            AddTriggersListener(sliders[i], EventTriggerType.PointerDown, UpdateValue);
        }

        AddTriggersListener(input.gameObject, EventTriggerType.Deselect, UpdatePlaceholder);
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
        input.text = null;
        changePopup.SetActive(true);

        GameObject obj = EventSystem.current.currentSelectedGameObject;

        category.text = "Change " + obj.name;

        oldNumber = obj.transform.Find("Number").GetComponent<Text>().text;
        oldFigure.text = oldNumber;
        vitalName = obj.name;

        confirmChange.onClick.AddListener(
            delegate ()
           {
               if (obj.name == vitalName)
               {
                   if (input.text != "")
                   {
                       obj.transform.Find("Number").GetComponent<Text>().text = input.text;
                       vitalNumber = input.text;
                   } else
                   {
                       vitalNumber = oldFigure.text;
                   }
                   update_vitals = true;
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
            obj.transform.parent.GetComponent<Image>().color = Color.white;
            objvis = true;
        }
        else
        {
            obj.GetComponent<Slider>().value = 0;
            obj.transform.parent.GetComponent<Image>().color = col;
            objvis = false;
        }
        vis_changed = true;
    }

    void UpdatePlaceholder(BaseEventData eventData)
    {
        oldFigure.text = oldNumber;
    }

    public void changeVolume()
    {
        volume_changed = true;
        volume = vol.value;
    }
}

