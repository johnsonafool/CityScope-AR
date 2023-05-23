using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
//using Newtonsoft.Json;
using TMPro;
/*
public class CWBOpenDataManager : MonoBehaviour
{
    enum opendataMode
    {
        currentMode,//即時資料
        predictMode //預測資料
    }

    opendataMode _opendataMode;

    public currentOpenData _currentOpenData;
    public predictOpenData _predictOpenData;

    [Header("CITY")]
    public GameObject[] cityRawImg;

    public string cwbAPIUrl, authorization = "";
    public float updateRate;

    void Start()
    {
        _currentOpenData.init();
        InvokeRepeating("enabledApiRequest", 1f, updateRate);
    }

    IEnumerator apiRequest(int index, string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log("Request url: " + url);
                    //Debug.Log("Received: " + webRequest.downloadHandler.text);

                    switch (_opendataMode)
                    {
                        case opendataMode.currentMode:
                            _currentOpenData.jsonConvert(index, webRequest.downloadHandler.text);
                            break;
                        case opendataMode.predictMode:
                            break;
                    }
                    break;
            }
        }
    }
    void enabledApiRequest()
    {
        string requestUrl = "";

        switch (_opendataMode)
        {
            case opendataMode.currentMode:
                for (int i = 0; i < cityRawImg.Length; i++)
                {
                    requestUrl = cwbAPIUrl + _currentOpenData.setCatalog() +
                        "?Authorization=" + authorization + "&stationId=" + _currentOpenData.setStationId(i) + "&elementName=" + _currentOpenData.elementName + "&parameterName=CITY";
                    StartCoroutine(apiRequest(i,requestUrl));
                }
                break;
            case opendataMode.predictMode:

                break;
               
        }
    }
    public void displayOneLocation(int index)
    {
        cityRawImg[index].SetActive(true);
    }

    public void disPlayAllLocations(bool enabled)
    {
        if (enabled == true)
        {
            for (int i = 0; i < cityRawImg.Length; i++)
            {
                cityRawImg[i].SetActive(true);
            }
        }
        if (enabled == false)
        {
            for (int i = 0; i < cityRawImg.Length; i++)
            {
                cityRawImg[i].SetActive(false);
            }
        }
    }


}

[Serializable]
public class currentDataParameter
{
    public string parameterName;
    public string parameterValue;
}

[Serializable]
public class currentDataWeatherElement
{
    public string elementName;
    public string elementValue;
}
[Serializable]
public class currentDataTime
{
    public string obsTime;
}

[Serializable]
public class currentDataLocation
{
    public string lat;
    public string lon;
    public string locationName;
    public string stationId;
    public currentDataTime time;
    public currentDataWeatherElement[] weatherElement;
    public currentDataParameter[] parameter;
}

[Serializable]
public class elementValue
{
    public string value;
    public string measures;
}

[Serializable]
public class time
{
    public string startTime;
    public string endTime;
    public elementValue[] elementValue;
}

[Serializable]
public class weatherElement
{
    public string elementName;
    public string description;
    public time[] time;
}

[Serializable]
public class location
{
    public string locationName;
    public string geocode;
    public string lat;
    public string lon;
    public weatherElement[] weatherElement;
}

[Serializable]
public class locations
{
    public string datasetDescription;
    public string locationsName;
    public string dataid;
    public location[] location;
}

[Serializable]
public class records
{
    public locations[] locations;
    public currentDataLocation[] location;
}

[Serializable]
public class jsonObj
{
    public string success;
    public records records;
}
*/