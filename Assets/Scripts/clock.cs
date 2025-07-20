using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class clock : MonoBehaviour
{
    [SerializeField] private TMP_Text clockText;
    [SerializeField] private TMP_Text dateText;

    private void Update()
    {
        if (updateLastChanged.isUpdated)
        {
            updateLastChanged.isUpdated = false;
            ChangeDate();
        }
    }
    private void ChangeDate()
    {
        DateTime time = DateTime.Now;
        //clockText.text = hour + ":" + minute + "  " + AMPM;
        if (PlayerPrefs.GetString("Time", "") == "")
        {
            dateText.text = "";
        }
        else
        {
            dateText.text = PlayerPrefs.GetString("Date", "__") + "   -->   " + "<color=#FF2B00>" + PlayerPrefs.GetString("Weekday", "__") + "</color>" + "   -->   " + PlayerPrefs.GetString("Time", "__") + "  " + PlayerPrefs.GetString("AMPM", "__");
        }
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}