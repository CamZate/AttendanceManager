using UnityEngine;
using System;
using System.Collections.Generic;

public static class updateLastChanged
{
    public static bool isUpdated = true;
    public static void record()
    {
        DateTime time = DateTime.Now;

        string hour = "";
        string minute = LeadingZero(time.Minute);
        string second = LeadingZero(time.Second);
        string AMPM = time.Hour > 12 ? "PM" : "AM";

        string day = LeadingZero(time.Day);
        string month = LeadingZero(time.Month);
        string year = LeadingZero(time.Year);
        string weekday = time.DayOfWeek.ToString();

        if (time.Hour > 12)
        {
            hour = LeadingZero(time.Hour - 12);
        }
        else
        {
            hour = LeadingZero(time.Hour);
        }

        PlayerPrefs.SetString("Date", day + "/" + month + "/" + year);
        PlayerPrefs.SetString("Time", hour + ":" + minute);
        PlayerPrefs.SetString("AMPM", AMPM);
        PlayerPrefs.SetString("Weekday", weekday);

        Debug.Log("Recorded Last Changed: " + PlayerPrefs.GetString("Date") + " " + PlayerPrefs.GetString("Time") + " " + PlayerPrefs.GetString("AMPM") + " " + PlayerPrefs.GetString("Weekday"));
        isUpdated = true;
    }

    private static string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}

