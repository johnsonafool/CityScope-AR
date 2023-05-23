using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.VFX;

public class DataSever : MonoBehaviour
{
    public enum Mode {total, each};
    public Mode mode;

    public Button huv, temp, rain ,weather;
    public string catalogValue;

    [Header("spatial effects")]
    [Header("0:huv, 1:temp, 2:pm25, 3:rain, 4:weather")]

    public GameObject[] visualObjs;
    public string[] locations;
    public EPAWebRequest _EPAWebRequest;
    public CWBWebRequest _CWBWebRequest;
    public TMP_Text VisualizeType;
    public float AllValue;
    public Text DebugChoose;
    //public Text DebugRay;

    public VFXController PM25Mat;
    public Material HUVMat, TEMPMat;
    public RainController RainMat;
    public SunController SunMat;
    public CloudController CloudMat;

    [Header("0:新北 ~ 5:高雄")] 
    public int locationIndex;

    void Awake()
    {
        for (int i = 0; i < visualObjs.Length; i++)
        {
            visualObjs[i].SetActive(false);
        }
    }
    void Start()
    {
        /*
        switch (mode)
        {
            case Mode.total:
                foreach (string location in locations)
                {
                    //_CWBWebRequest.GetTEMPData(location);
                }
                break;
            case Mode.each:
                InvokeRepeating("calledEPASever", 1f, 2f);
                InvokeRepeating("calledCWBSever", 1f, 2f);
                break;
        }
        */
    }
    public void setCatalog(string _catalog)
    {
        catalogValue = _catalog;
        Debug.Log("catalog: " + catalogValue);

        VisualizeType.text = catalogValue.ToString().ToUpper();
        DebugChoose.text = catalogValue.ToString();
    }

    public void HuvInfo(string location)
    {
        for(int i = 0; i < visualObjs.Length; i++)
        {
            visualObjs[i].SetActive(false);
        }
        visualObjs[0].SetActive(true);

        _CWBWebRequest.huvData(location);
    }

    public void TempInfo(string location)
    {
        for (int i = 0; i < visualObjs.Length; i++)
        {
            visualObjs[i].SetActive(false);
        }
        visualObjs[1].SetActive(true);

        _CWBWebRequest.tempData(location);
    }

    public void Pm25Info(string location)
    {
        for (int i = 0; i < visualObjs.Length; i++)
        {
            visualObjs[i].SetActive(false);
        }
        visualObjs[2].SetActive(true);

        switch(location)
        {
            case "新北":
                _EPAWebRequest.GetPM25Data("新北市", "板橋");
                break;
            case "臺北":
                _EPAWebRequest.GetPM25Data("臺北市", "松山");
                break;
            case "武陵":
                _EPAWebRequest.GetPM25Data("桃園市", "桃園");
                break;
            case "臺中":
                _EPAWebRequest.GetPM25Data("臺中市", "忠明");
                break;
            case "臺南":
                _EPAWebRequest.GetPM25Data("臺南市", "臺南");
                break;
            case "高雄":
                _EPAWebRequest.GetPM25Data("高雄市", "小港");
                break;
        }
    }
    public void RainInfo(string location)
    {
        for (int i = 0; i < visualObjs.Length; i++)
        {
            visualObjs[i].SetActive(false);
        }
        visualObjs[3].SetActive(true);

        _CWBWebRequest.rainData(location);
    }
    public void WeatherInfo(string location)
    {
        for (int i = 0; i < visualObjs.Length; i++)
        {
            visualObjs[i].SetActive(false);
        }
        visualObjs[4].SetActive(true);

        _CWBWebRequest.weatherData(location);
    }

    void Update()
    {
        if(PM25Mat != null)
        {
            setPM25Effect();
        }
        if (HUVMat != null)
        {
            setHUVEffect();
        }
        if (TEMPMat != null)
        {
            TEMPEffect();
        }
        if (RainMat != null)
        {
            SetRainEffect();
        }
        if (SunMat != null)
        {
            SetSunEffect();
        }
        if (CloudMat !=null)
        {
            SetCloudEffect();
        }
    }
    void setPM25Effect()
    {
        AllValue = (float)_EPAWebRequest.pm25Value;
        PM25Mat.maxParticles = _EPAWebRequest.pm25Value * 1000;
    }

    void setHUVEffect()
    {
        AllValue = (float)_CWBWebRequest.huvValue;
        switch (Mathf.RoundToInt(_CWBWebRequest.huvValue))
        {
            case 0:
                HUVMat.color = new Vector4(0.08f, 0.5f, 0, 1);
                break;
            case 1:
                HUVMat.color = new Vector4(0.08f, 0.5f, 0, 1);
                break;
            case 2:
                HUVMat.color = new Vector4(0.08f, 0.5f, 0, 1);
                break;
            case 3:
                HUVMat.color = new Vector4(1, 0.8f, 0.08f, 1);
                break;
            case 4:
                HUVMat.color = new Vector4(1, 0.8f, 0.08f, 1);
                break;
            case 5:
                HUVMat.color = new Vector4(1, 0.8f, 0.08f, 1);
                break;
            case 6:
                HUVMat.color = new Vector4(1, 0.3f, 0, 1);
                break;
            case 7:
                HUVMat.color = new Vector4(1, 0.3f, 0, 1);
                break;
            case 8:
                HUVMat.color = new Vector4(1, 0.15f, 0.15f, 1);
                break;
            case 9:
                HUVMat.color = new Vector4(1, 0.15f, 0.15f, 1);
                break;
            case 10:
                HUVMat.color = new Vector4(1, 0.15f, 0.15f, 1);
                break;
            default:
                HUVMat.color = new Vector4(0.8f, 0, 0.9f, 1);
                break;
        }
    }

    void TEMPEffect()
    {
        AllValue = (float)_CWBWebRequest.tempValue;
        if (_CWBWebRequest.tempValue > 30)
        {
            TEMPMat.color = SetSphereColor.setHotTemp();
        }
        else if (_CWBWebRequest.tempValue >= 25 && _CWBWebRequest.tempValue <= 30)
        {
            TEMPMat.color = SetSphereColor.setHotTemp();
        }
        else if (_CWBWebRequest.tempValue < 25)
        {
            TEMPMat.color = SetSphereColor.setColdTemp();
        }
    }

    void SetRainEffect()
    {
        AllValue = (float)_CWBWebRequest.rainValue;
        RainMat.RainAmount = _CWBWebRequest.rainValue;
    }

    void SetSunEffect()
    {
        SunMat.WeatherStatus = _CWBWebRequest.weatherValue;
    }

    void SetCloudEffect()
    {
        CloudMat.WeatherStatus = _CWBWebRequest.weatherValue;
    }
}
