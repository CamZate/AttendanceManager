using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class clock : MonoBehaviour
{
    [SerializeField] private TMP_Text clockText;
    [SerializeField] private TMP_Text dateText;

    private void Update() {
        DateTime time = DateTime.Now;

        string hour = "";
        string minute = LeadingZero(time.Minute);
        string second = LeadingZero(time.Second);
        string AMPM = time.Hour > 12 ? "PM" : "AM";

        string day = LeadingZero(time.Day);
        string month = LeadingZero(time.Month);
        string year = LeadingZero(time.Year);
        string weekday = time.DayOfWeek.ToString();

        if(time.Hour >12){ 
            hour = LeadingZero(time.Hour-12);
        }else{
            hour = LeadingZero(time.Hour);
        }
        clockText.text = hour + ":" + minute + "  " + AMPM;
        dateText.text = day + "/" + month + "/" + year + "   -->  " + "<color=#FF2B00>" + weekday + "</color>";
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}