using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityTemp : MonoBehaviour
{
    public int CountyNumber;
    public float CountyTemp;
    public GameObject DataObject;

    // Start is called before the first frame update
    void Start()
    {
        DataObject = GameObject.Find("ReadTempData");
    }

    // Update is called once per frame
    void Update()
    {
        ReadCsv readCsvScript = DataObject.GetComponent<ReadCsv>();
        CountyTemp = float.Parse(readCsvScript.CountyList[CountyNumber]);
    }
}
