using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Globalization;

public class Calendar : MonoBehaviour
{
    public Text HeaderLabel;         //The label used to show the Month
    public GameObject Labels;

    private DateTime iMonth;
    private DateTime curDisplay;
    private Color active = new Color(0.6f, 0.6f, 0.6f, 1.0f);
    private Color inactive = new Color(0.2735849f, 0.2735849f, 0.2735849f, 1.0f);

    void Start()
    {
        iMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        CreateCalendar();
    }

    /*Sets the days to their correct labels*/
    void CreateCalendar()
    {
        curDisplay = iMonth;
        int startDay = (int) curDisplay.DayOfWeek;
        curDisplay = curDisplay.AddDays(-startDay);
        foreach (Transform child in Labels.transform)
        {
            if (curDisplay.Month != iMonth.Month)
                child.GetComponent<Text>().color = inactive;
            else
                child.GetComponent<Text>().color = active;
            child.GetComponent<Text>().text = curDisplay.Day.ToString();
            curDisplay = curDisplay.AddDays(1);
        }
        HeaderLabel.text = iMonth.ToString("MMMM") + " " + iMonth.Year;
    }



    /*when right arrow clicked go to next month */
    public void nextMonth()
    {
        iMonth = iMonth.AddMonths(1);
        clearLabels();
        CreateCalendar();
    }

    /*when left arrow clicked go to previous month */
    public void previousMonth()
    {
        iMonth = iMonth.AddMonths(-1);
        clearLabels();
        CreateCalendar();
    }

    /*clears all the day labels*/
    void clearLabels()
    {
        foreach (Transform child in Labels.transform)
        {
            child.GetComponent<Text>().text = null;
        }
    }
}