using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class semesterData
{
    public Dictionary<int, Dictionary<string, float[]>> data = new Dictionary<int, Dictionary<string, float[]>>();

    public semesterData(Dictionary<int, Dictionary<string, float[]>> dataTemp)
    {
        if (dataTemp != null)
        {
            data = dataTemp;
        }
    }
}