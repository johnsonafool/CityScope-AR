using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ReadCsv : MonoBehaviour
{
    public TextAsset textAssetData;
    public List<string> CountyList = new List<string>();

    void Start()
    {
        StartReadCsv();
    }

    void StartReadCsv()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, System.StringSplitOptions.None);

        string[] strr = new string[17];

        for (int i = 0; i < 17; i++)
        {
            for (int j = 2 * i; j < 2 * (i + 1); j++)
            {
                strr[i] = data[j];     // combine the string
            }
            CountyList.Add(strr[i]);     // store the player.
        }
        

        //Debug.Log("Hi! " + CountyList[1]);

    }
}