using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UntiyEngine.Networking;
using UnityEngine.UI;


public class FetchData : MonoBehaviour
{
    private const string URL = "https://opendata.cwb.gov.tw/api/v1/rest/datastore/O-A0001-001?Authorization=CWB-764E7116-819C-42F3-9611-1C859945418F";
    public TextAsset textAssetData;
    public List<string> CountyList = new List<string>();

    void Start()
    {
        ProcessRequet();
    }

    // void StartReadCsv()
    // {
    //     string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);

    //     string[] strr = new string[17];

    //     for (int i = 0; i < 17; i++)
    //     {
    //         for (int j = 2 * i; j < 2 * (i + 1); j++)
    //         {
    //             strr[i] = data[j];     // combine the string
    //         }
    //         CountyList.Add(strr[i]);     // store the player.
    //     }        
    //     //Debug.Log("Hi! " + CountyList[1]);
    // }

    public void GenertaeRequest()
    {
        StartCoroutine(ProcessRequest(URL));
    }

    private IEnumerator ProcessRequet(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                JSONNode itemsData = JSON.Parse(request.downloadHandler.text);             

                List records = itemsData["result"];

                CountyList.Add(records);                

                // Debug.Log("The generated item is: \nName: " + itemsData["items"]["backpack"][randomNum]["name"]);
            }
        }
    }
}