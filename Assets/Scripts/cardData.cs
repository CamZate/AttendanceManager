using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class cardData
{
    public string cardName;
    public Dictionary<string, Dictionary<string,int>> data = new Dictionary<string, Dictionary<string,int>>();

    public cardData(card cardStats, Dictionary<string, Dictionary<string,int>> dataTemp, bool removal = false){
        
        if (dataTemp != null){
            data = dataTemp;
        }
        if(removal){
            data.Remove(cardStats.cardName);
            return;
        }
        AddValue(data, cardStats.cardName, "LectureA", cardStats.lectAmt);
        AddValue(data, cardStats.cardName, "LabA", cardStats.labAmt);
        AddValue(data, cardStats.cardName, "TutorialA", cardStats.tutAmt);

        AddValue(data, cardStats.cardName, "LectureT", cardStats.lectTotal);
        AddValue(data, cardStats.cardName, "LabT", cardStats.labTotal);
        AddValue(data, cardStats.cardName, "TutorialT", cardStats.tutTotal);
    }

    static void AddValue(Dictionary<string, Dictionary<string, int>> dict, string key1, string key2, int value)
    {
        if (!dict.ContainsKey(key1))
        {
            dict[key1] = new Dictionary<string, int>();
        }
        dict[key1][key2] = value;
    }

}