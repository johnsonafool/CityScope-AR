using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class EPARawData
{
    public string resource_id;
    public List<EPARecords> records;
}

[System.Serializable]
public class EPARecords
{
    public string site;
    public string county;
    public string pm25;
    public string datacreationdate;
    public string itemunit;
}

public class EPAWebRequest : MonoBehaviour
{
    public string EPASever;
    string RawJson;

    //public GameObject PM25Prefab;
    //public Text DebugRay;

    public float pm25Value;
    public void GetPM25Data(string countyName, string siteName)
    {
        StartCoroutine(GetRequest(EPASever, countyName, siteName));
    }

    IEnumerator GetRequest(string uri, string countyName, string siteName)
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
                    EnabledPM25Info(RawJson, countyName, siteName);
                    break;
            }
        }
    }

    void EnabledPM25Info(string json, string countyName, string siteName)
    {
        EPARawData rawData = JsonUtility.FromJson<EPARawData>(json);
        
        foreach (EPARecords record in rawData.records)
        {
            if(record.county == countyName)
            {
                if(record.site == siteName)
                {
                    PM25Info(record);
                }
            }
        }    
    }

    void PM25Info(EPARecords record)
    {
       // Instantiate(PM25Prefab, Panel.transform);
       // PM25Prefab.transform.GetChild(0).GetComponent<Text>().text = record.county;
       // PM25Prefab.transform.GetChild(1).GetComponent<Text>().text = record.site;
       // PM25Prefab.transform.GetChild(2).GetComponent<TMP_Text>().text = record.pm25 + " " + record.itemunit;
       // PM25Prefab.transform.GetChild(3).GetComponent<TMP_Text>().text = record.datacreationdate;
        pm25Value = float.Parse(record.pm25);
        Debug.Log("pm 2.5 value: " + pm25Value);
        //DebugRay.text = "pm 2.5 value: " + pm25Value.ToString();
    }
}
