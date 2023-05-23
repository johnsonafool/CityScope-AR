using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour
{
    public GameObject SunModel;
    public string WeatherStatus;

    void Start()
    {
        SunModel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SunModel != null)
        {
            if(WeatherStatus == "晴")
            {
                SunModel.SetActive(true);
            }
            else
            {
                SunModel.SetActive(false);
            }
        }
    }
}
