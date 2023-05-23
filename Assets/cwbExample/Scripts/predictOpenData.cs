using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
//using Newtonsoft.Json;
using TMPro;
/*
public class predictOpenData : MonoBehaviour
{
    public CWBOpenDataManager _CWBOpenDataManager;

    string locationName = "";
    public string elementName = "";

    [Header("2D UI ICON")]
    public Sprite[] weather;
    public Text locationNameText;

    [Header("SECTIONS DETAILS")]
    public GameObject[] details;

    int currentSectionIndex = 0;
    int maxSectionsCount = 0;
    void init()
    {
        locationName = "F-D0047-061";
        elementName = "Wx";
    }
    public string setLocationName(int index)
    {
        switch (index)
        {
            case 0:
                locationName = "F-D0047-061";
                break;
            case 1:
                locationName = "F-D0047-069";
                break;
            case 2:
                locationName = "F-D0047-005";
                break;
            case 3:
                locationName = "F-D0047-073";
                break;
            case 4:
                locationName = "F-D0047-077";
                break;
            case 5:
                locationName = "F-D0047-065";
                break;
            default:
                locationName = "";
                break;
        }
        return locationName;
    }
    public void setElementName(string element)
    {
        elementName = element;
    }
    public void jsonConvert(int index, string text)
    {
        jsonObj data = JsonUtility.FromJson<jsonObj>(text);
        maxSectionsCount = data.records.locations[0].location.Length;
        locationNameText.text = data.records.locations[0].location[index].locationName;

        for (int i = 0; i < data.records.locations[0].location.Length; i++)
        {
            //weatherTexture(details[i].transform.GetChild(0).GetComponent<RawImage>(), data.records.locations[0].location[index].weatherElement[0].time[i].elementValue[0].value);
            details[i].transform.GetChild(1).GetComponent<Text>().text = data.records.locations[0].location[index].weatherElement[0].time[i].elementValue[0].value;
            details[i].transform.GetChild(2).GetComponent<Text>().text = data.records.locations[0].location[index].weatherElement[0].time[i].startTime;
            details[i].transform.GetChild(3).GetComponent<Text>().text = data.records.locations[0].location[index].weatherElement[0].time[i].endTime;
        }

        enabledWeatherDetails(_CWBOpenDataManager.cityRawImg[index].GetComponent<RawImage>(), elementName, data);
    }
    void enabledWeatherDetails(RawImage rawimg, string element, jsonObj data)
    {
        //var location = data.records.location[0].parameter[0].parameterValue;
        //var obstime = data.records.location[0].time.obsTime;
        //var value = data.records.location[0].weatherElement[0].elementValue;
        
        

        
        foreach (var location in data.records.locations[0].location)
        {
            foreach (var weatherElement in location.weatherElement)
            {
                foreach (var time in weatherElement.time)
                {

                }
            }
        }
    }
    
    public void prevSectionInfo()
    {
        currentSectionIndex -= 1;
        if (currentSectionIndex <= 0)
        {
            currentSectionIndex = 0;
        }
    }
    public void nextSectionInfo()
    {
        currentSectionIndex += 1;
        if (currentSectionIndex >= maxSectionsCount)
        {
            currentSectionIndex = maxSectionsCount;
        }
    }
}
*/