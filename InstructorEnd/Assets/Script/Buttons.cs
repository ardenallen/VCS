using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private Image im;
    private Color enabled;
    private Color disabled;
    // Start is called before the first frame update
    void Start()
    {
        im = this.transform.Find("Image").GetComponent<Image>();
        disabled = new Color(0.4196078f, 0.4196078f, 0.4196078f, 1.0f); 
        enabled = new Color(0.1803922f, 0.7686275f, 0.6509804f, 1.0f);
    }

    // Update is called once per frame
    public void OnClick()
    {
        if (im.color != enabled)
        {
            im.color = enabled;
        }
        else
        {
            im.color = disabled;
        }
    }
}
