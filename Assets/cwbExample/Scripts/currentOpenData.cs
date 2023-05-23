using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
//using Newtonsoft.Json;
using TMPro;

/*
public class currentOpenData : MonoBehaviour
{
    public CWBOpenDataManager _CWBOpenDataManager;

    string catalog = "";
    string stationId = "";
    public string elementName = "";

    [Header("2D ICON")]
    public Sprite[] temp;
    public Sprite[] weather;
    public Sprite d_tx, d_tn, rain, h_uvi, humd;


    [Header("3D objects")]
    public GameObject[] uvObjs;
    public void init()
    {
        catalog = "O-A0003-001";
        stationId = "466920";
        elementName = "TEMP";
    }

    public string setCatalog()
    {
        return catalog;
    }
    public string setStationId(int index)
    {
        switch (index)
        {
            case 0://台北
                stationId = "466920";
                break;
            case 1://新北
                stationId = "466881";
                break;
            case 2://桃園
                stationId = "467050";
                break;
            case 3://台中
                stationId = "467490";
                break;
            case 4://台南
                stationId = "467410";
                break;
            case 5://高雄
                stationId = "467440";
                break;
            default:
                stationId = null;
                break;
        }
        return stationId;
    }
    public void setElementName(string element)
    {
        elementName = element;
    }
    
    public void jsonConvert(int index, string text)
    {
        jsonObj data = JsonUtility.FromJson<jsonObj>(text);
        enabledWeatherDetails(_CWBOpenDataManager.cityRawImg[index].GetComponent<RawImage>(), elementName, data);
    }
    void enabledWeatherDetails(RawImage rawimg,string element, jsonObj data)
    {
        var location = data.records.location[0].parameter[0].parameterValue;
        var obstime = data.records.location[0].time.obsTime;
        var value = data.records.location[0].weatherElement[0].elementValue;

        switch (element)
        {
            case "TEMP"://溫度，單位 攝氏
                //TEXTURE//
                if (float.Parse(value) >= 15 && float.Parse(value) <= 20)
                {
                    rawimg.texture = temp[0].texture;
                }
                else if (float.Parse(value) > 20 && float.Parse(value) <= 25)
                {
                    rawimg.texture = temp[1].texture;
                }
                else if (float.Parse(value) > 25)
                {
                    rawimg.texture = temp[2].texture;
                }
                else if (float.Parse(value) < 15)
                {
                    rawimg.texture = temp[3].texture;
                }
                //TEXT//
                rawimg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "觀測地點:" + location;
                rawimg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "觀測時間:" + obstime;
                rawimg.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "目前攝氏溫度:" + value;
                break;
            case "D_TX"://本日最高溫，單位 攝氏
                //TEXTURE//
                rawimg.texture = d_tx.texture;
                //TEXT//
                rawimg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "觀測地點:" + location;
                rawimg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "觀測時間:" + obstime;
                rawimg.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "本日最高溫:" + value;
                break;
            case "D_TN"://本日最低溫，單位 攝氏
                //TEXTURE//
                rawimg.texture = d_tn.texture;
                //TEXT//
                rawimg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "觀測地點:" + location;
                rawimg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "觀測時間:" + obstime;
                rawimg.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "本日最低溫:" + value;
                break;
            case "Weather"://十分鐘天氣現象描述
                //TEXTURE//
                switch (value)
                {
                    case "晴":
                        rawimg.texture = weather[0].texture;
                        break;
                    case "陰":
                        rawimg.texture = weather[1].texture;
                        break;
                    case "多雲":
                        rawimg.texture = weather[2].texture;
                        break;
                    case "短暫雨":
                        rawimg.texture = weather[3].texture;
                        break;
                    default:
                        Debug.Log("situation etc. :" + data);
                        break;
                }
                //TEXT//
                rawimg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "觀測地點:" + location;
                rawimg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "觀測時間:" + obstime;
                rawimg.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "目前天氣狀況:" + value;
                break;
            case "24R"://日累積雨量，單位 毫米
                //TEXTURE//
                rawimg.texture = rain.texture;
                //TEXT//
                rawimg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "觀測地點:" + location;
                rawimg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "觀測時間:" + obstime;
                rawimg.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "本日累積雨量:" + value;
                break;
            case "H_UVI"://小時紫外線指數
                Debug.Log("H_UVI:" + float.Parse(value));
                for(int i = 0;i< uvObjs.Length;i++)
                {
                    uvObjs[i].SetActive(false);
                }
                Instantiate(uvObjs[Mathf.RoundToInt(float.Parse(value))], this.transform.position, this.transform.rotation);
                //TEXTURE//
                rawimg.texture = h_uvi.texture;
                //TEXT//
                rawimg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "觀測地點:" + location;
                rawimg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "觀測時間:" + obstime;
                rawimg.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "小時紫外線指數:" + value;
                break;
            case "HUMD"://相對濕度，單位 百分比率，此處以實數 0-1.0 記錄
                //TEXTURE//
                rawimg.texture = humd.texture;
                //TEXT//
                rawimg.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "觀測地點:" + location;
                rawimg.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "觀測時間:" + obstime;
                rawimg.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "相對溼度:" + value;
                break;
        }
    }
}
*/