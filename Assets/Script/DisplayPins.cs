using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DisplayPins : MonoBehaviour
{
    //縣市編號
    public int CountyNumber; 

    //顯示模型
    public GameObject Pin;
    public GameObject RainyNight;
    public GameObject RainyDay;
    public GameObject CloudyDay;
    public GameObject CloudyNight;
    public GameObject SunnyDay;
    public GameObject SunnyNight;

    public GameObject DataObject;

    public int WeatherNum;


    void Start()
    {
        Pin.SetActive(true);
        RainyNight.SetActive(false);
        RainyDay.SetActive(false);
        CloudyDay.SetActive(false);
        CloudyNight.SetActive(false);
        SunnyDay.SetActive(false);
        SunnyNight.SetActive(false);
    }



    void Update()
    {
        
    }

    public void ShowWeather() //以下為根據一個csv檔案中的資料顯示天氣模型
    {
        ReadCsv readCsvScript = DataObject.GetComponent<ReadCsv>();

        WeatherNum = int.Parse(readCsvScript.CountyList[CountyNumber]); 
        
        Pin.SetActive(false);

        DateTime now = DateTime.Now;
        DateTime start = DateTime.Today.AddHours(6);
        DateTime end = DateTime.Today.AddHours(18);

        // 判斷當前時間是否在6點到18點之間
        if (now >= start && now <= end)
        {
            if (WeatherNum == 1 || WeatherNum == 2)
            {
                SunnyDay.SetActive(true);
            }
            else if (WeatherNum >= 3 && WeatherNum <= 7)
            {
                CloudyDay.SetActive(true);
            }
            else
            {
                RainyDay.SetActive(true);
            }

        }
        else
        {
            if (WeatherNum == 1 || WeatherNum == 2)
            {
                SunnyNight.SetActive(true);
            }
            else if (WeatherNum >= 3 && WeatherNum <= 7)
            {
                CloudyNight.SetActive(true);
            }
            else
            {
                RainyNight.SetActive(true);
            }

        }
                
    }


    public void BackDefault()
    {
        Pin.SetActive(true);
        RainyNight.SetActive(false);
        RainyDay.SetActive(false);
        CloudyDay.SetActive(false);
        CloudyNight.SetActive(false);
        SunnyDay.SetActive(false);
        SunnyNight.SetActive(false);
    }


}
