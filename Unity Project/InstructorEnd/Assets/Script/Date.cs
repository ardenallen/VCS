using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Date : MonoBehaviour
{
    public Text time;
    public Text date;
    // Start is called before the first frame update
    void Start()
    {
        DateTime start = RoundUp(DateTime.Now, TimeSpan.FromMinutes(10));
        DateTime end = start.AddMinutes(20);
        time.text = start.ToString("t", CultureInfo.CreateSpecificCulture("de-DE")) + " - " + end.ToString("t", CultureInfo.CreateSpecificCulture("de-DE"));
        date.text = start.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"));
    }

    DateTime RoundUp(DateTime dt, TimeSpan d)
    {
        return new DateTime((dt.Ticks + d.Ticks - 1) / d.Ticks * d.Ticks, dt.Kind);
    }
}
