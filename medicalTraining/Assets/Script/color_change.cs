using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class color_change : MonoBehaviour
{
    public int upperLimit;
    public int lowerLimit;
    private Text number;
    private Color normal;

    private ControlPanelManagement cpm;
    private string objName;

    // Update is called once per frame
    void Start()
    {
        number = this.transform.Find("Number").GetComponent<Text>();
        normal = number.color;

        objName = this.gameObject.name;
        cpm = GameObject.Find("TrainingManager").GetComponent<ControlPanelManagement>();
    }

    void Update()
    {  
        int value = int.Parse(number.text);
        if (value > upperLimit  || value < lowerLimit)
        {
            number.color = Color.red;   
        }
        else
        {
            number.color = normal;
        }

        if (objName == "HR")
        {
            if (value >= 101)
            {
                cpm.videoPlayer.clip = cpm.hr125;
            }
            else
                cpm.videoPlayer.clip = cpm.hr76;
        }
    }
}
