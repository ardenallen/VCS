using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class color_change : MonoBehaviour
{
    public int upperLimit;
    public int lowerLimit;
    private Text number;
    public Color normal;

    // Update is called once per frame
    void Start()
    {
        number = this.transform.Find("Number").GetComponent<Text>();
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

    }
}
