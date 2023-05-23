using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


[System.Serializable]

public class CWBRawData
{
    public string success;
    public CWBRecords records;
    public Result result;
}

[System.Serializable]
public class CWBRecords
{
    public List<Location> location;
}

[System.Serializable]
public class Result
{
    public string resource_id;
}

[System.Serializable]
public class WeatherElement
{
    public string elementName;
    public string elementValue;
}

[System.Serializable]
public class Location
{
    public string lat;
    public string lon;
    public string locationName;
    public List<WeatherElement> weatherElement;
}

public class CWBWebRequest : MonoBehaviour
{
    public DataSever dataSever;

    public string CWBSever;
    string RawJson;
    public TMP_Text DebugRay;
    public string weatherValue;
    public float huvValue, tempValue, rainValue;

    public GameObject[] NightRain, DayRain, NigntCloud, DayCloud, NightSunny, DaySunny;
    public GameObject[] Pins;
    
    public void huvData(string locationName)
    {
        StartCoroutine(GetHUVRequest(CWBSever, locationName));
    }
    public void tempData(string locationName)
    {
        StartCoroutine(GetTEMPRequest(CWBSever, locationName));
    }
    public void rainData(string locationName)
    {
        StartCoroutine(GetRainRequest(CWBSever, locationName));
    }
    public void weatherData(string locationName)
    {
        StartCoroutine(GetWeatherRequest(CWBSever, locationName));
    }
    IEnumerator GetHUVRequest(string uri, string locationName)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    RawJson = webRequest.downloadHandler.text;
                    EnabledHUVInfo(RawJson, locationName);
                    break;
            }
        }
    }
    IEnumerator GetTEMPRequest(string uri, string locationName)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    RawJson = webRequest.downloadHandler.text;
                    EnabledTEMPInfo(RawJson, locationName);
                    break;
            }
        }
    }
    IEnumerator GetRainRequest(string uri, string locationName)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    RawJson = webRequest.downloadHandler.text;
                    EnabledRainInfo(RawJson, locationName);
                    break;
            }
        }
    }
    IEnumerator GetWeatherRequest(string uri, string locationName)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    RawJson = webRequest.downloadHandler.text;
                    EnabledWeatherInfo(RawJson, locationName);
                    break;
            }
        }
    }

    void EnabledHUVInfo(string json, string locationName)
    {
        CWBRawData rawData = JsonUtility.FromJson<CWBRawData>(json);
        foreach (Location location in rawData.records.location)
        {
            if (location.locationName == locationName)
            {
                foreach (WeatherElement weatherElement in location.weatherElement)
                {
                    if (weatherElement.elementName == "H_UVI")
                    {
                        huvValue = float.Parse(weatherElement.elementValue);
                        Debug.Log("H_UVI: " + weatherElement.elementValue);
                        DebugRay.text = "H_UVI: " + weatherElement.elementValue.ToString();
                    }
                }
            }
        }
    }
    void EnabledTEMPInfo(string json, string locationName)
    {
        CWBRawData rawData = JsonUtility.FromJson<CWBRawData>(json);
        foreach (Location location in rawData.records.location)
        {
            if (location.locationName == locationName)
            {
                foreach (WeatherElement weatherElement in location.weatherElement)
                {
                    if (weatherElement.elementName == "TEMP")
                    {
                        tempValue = float.Parse(weatherElement.elementValue);
                        Debug.Log("TEMP: " + weatherElement.elementValue);
                        DebugRay.text = "TEMP: " + weatherElement.elementValue.ToString();
                    }
                }
            }
        }       
    }
    void EnabledRainInfo(string json, string locationName)
    {
        CWBRawData rawData = JsonUtility.FromJson<CWBRawData>(json);
        foreach (Location location in rawData.records.location)
        {
            if (location.locationName == locationName)
            {
                foreach (WeatherElement weatherElement in location.weatherElement)
                {
                    if (weatherElement.elementName == "24R")
                    {
                        rainValue = float.Parse(weatherElement.elementValue);
                        Debug.Log("24R: " + weatherElement.elementValue);
                        DebugRay.text = "24R: " + weatherElement.elementValue.ToString();
                    }
                }
            }
        }
    }
    void EnabledWeatherInfo(string json, string locationName)
    {
        CWBRawData rawData = JsonUtility.FromJson<CWBRawData>(json);
        foreach (Location location in rawData.records.location)
        {
            if (location.locationName == locationName)
            {
                foreach (WeatherElement weatherElement in location.weatherElement)
                {
                    if (weatherElement.elementName == "Weather")
                    {
                        weatherValue = weatherElement.elementValue;

                        DateTime now = DateTime.Now;
                        DateTime start = DateTime.Today.AddHours(6);
                        DateTime end = DateTime.Today.AddHours(18);

                        if (now >= start && now <= end)
                        {
                            switch (weatherValue)
                            {
                                case "陰":
                                    initAllWeather();
                                    Pins[dataSever.locationIndex].SetActive(false);
                                    DayCloud[dataSever.locationIndex].SetActive(true);
                                    break;
                                case "晴":
                                    initAllWeather();
                                    Pins[dataSever.locationIndex].SetActive(false);
                                    DaySunny[dataSever.locationIndex].SetActive(true);
                                    break;
                                case "雨":
                                    initAllWeather();
                                    Pins[dataSever.locationIndex].SetActive(false);
                                    DayRain[dataSever.locationIndex].SetActive(true);
                                    break;
                                default:
                                    initAllWeather();
                                    Pins[dataSever.locationIndex].SetActive(false);
                                    DaySunny[dataSever.locationIndex].SetActive(true);
                                    Debug.Log("其他狀況");
                                    break;
                            }
                        }
                        else
                        {
                            switch (weatherValue)
                            {
                                case "陰":
                                    initAllWeather();
                                    Pins[dataSever.locationIndex].SetActive(false);
                                    NigntCloud[dataSever.locationIndex].SetActive(true);
                                    break;
                                case "晴":
                                    initAllWeather();
                                    Pins[dataSever.locationIndex].SetActive(false);
                                    NightSunny[dataSever.locationIndex].SetActive(true);
                                    break;
                                case "雨":
                                    initAllWeather();
                                    Pins[dataSever.locationIndex].SetActive(false);
                                    NightRain[dataSever.locationIndex].SetActive(true);
                                    break;
                                default:
                                    initAllWeather();
                                    Pins[dataSever.locationIndex].SetActive(false);
                                    NightSunny[dataSever.locationIndex].SetActive(true);
                                    Debug.Log("其他狀況");
                                    break;
                            }
                        }
                        Debug.Log("Weather: " + weatherElement.elementValue);
                        DebugRay.text = "Weather: " + weatherElement.elementValue.ToString();
                    }
                }
            }
        }
    }

    public void initAllWeather()
    {
        for(int i = 0; i < Pins.Length; i++)
        {
            Pins[i].SetActive(true);
        }

        for (int i = 0; i < NightRain.Length; i++)
        {
            NightRain[i].SetActive(false);
        }
        for (int i = 0; i < NightSunny.Length; i++)
        {
            NightSunny[i].SetActive(false);
        }
        for (int i = 0; i < NigntCloud.Length; i++)
        {
            NigntCloud[i].SetActive(false);
        }
        for (int i = 0; i < DayRain.Length; i++)
        {
            DayRain[i].SetActive(false);
        }
        for (int i = 0; i < DayCloud.Length; i++)
        {
            DayCloud[i].SetActive(false);
        }
        for (int i = 0; i < DaySunny.Length; i++)
        {
            DaySunny[i].SetActive(false);
        }
    }


    void initNightWeather()
    {
        for (int i = 0; i < NightRain.Length; i++)
        {
            NightRain[i].SetActive(true);
        }
        for (int i = 0; i < NightSunny.Length; i++)
        {
            NightSunny[i].SetActive(true);
        }
        for (int i = 0; i < NigntCloud.Length; i++)
        {
            NigntCloud[i].SetActive(true);
        }
        for (int i = 0; i < DayRain.Length; i++)
        {
            DayRain[i].SetActive(false);
        }
        for (int i = 0; i < DayCloud.Length; i++)
        {
            DayCloud[i].SetActive(false);
        }
        for (int i = 0; i < DaySunny.Length; i++)
        {
            DaySunny[i].SetActive(false);
        }
    }
    void initDayWeather()
    {
        for (int i = 0; i < NightRain.Length; i++)
        {
            NightRain[i].SetActive(false);
        }
        for (int i = 0; i < NightSunny.Length; i++)
        {
            NightSunny[i].SetActive(false);
        }
        for (int i = 0; i < NigntCloud.Length; i++)
        {
            NigntCloud[i].SetActive(false);
        }
        for (int i = 0; i < DayRain.Length; i++)
        {
            DayRain[i].SetActive(true);
        }
        for (int i = 0; i < DayCloud.Length; i++)
        {
            DayCloud[i].SetActive(true);
        }
        for (int i = 0; i < DaySunny.Length; i++)
        {
            DaySunny[i].SetActive(true);
        }
    }
}
