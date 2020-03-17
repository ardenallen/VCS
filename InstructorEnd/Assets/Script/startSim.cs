using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startSim : MonoBehaviour
{
    public Sprite start;
    public Sprite stop;
    private Button but;

    private bool recording;
    private Text _text;
    private Text _time;

    private int total;
    private TimeSpan t;

    // Start is called before the first frame update
    void Start()
    {
        recording = false;
        _text = transform.Find("Text").GetComponent<Text>();
        _time = transform.Find("Time").GetComponent<Text>();
        but = GetComponent<Button>();
        total = 0;
        t = new TimeSpan();
    }

    // Update is called once per frame
    void Update()
    {
        if (recording)
        {
            t = TimeSpan.FromMilliseconds(total);
            total += (int)(Time.deltaTime * 1000);
        }
        _time.text = t.Hours.ToString("D2") + ":" + t.Minutes.ToString("D2") + ":" + t.Seconds.ToString("D2");       
    }

    public void OnClick()
    {
        recording = !recording;
        if (recording)
        {
            _text.text = "Stop Simulation";
            but.image.sprite = stop;
        }
        else
        {
            _text.text = "Start Simulation";
            but.image.sprite = start;
        }
    }

}
