using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public GameObject CloudModel;
    public string WeatherStatus;

    void Start()
    {
        CloudModel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (CloudModel != null)
        {
            if (WeatherStatus == "ณฑ")
            {
                CloudModel.SetActive(true);
            }
            else
            {
                CloudModel.SetActive(false);
            }
        }
    }
}
