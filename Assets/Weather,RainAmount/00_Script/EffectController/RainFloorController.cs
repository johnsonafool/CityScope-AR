using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainFloorController : MonoBehaviour
{
    public GameObject WaterModel;
    public float RainAmount;

    // Update is called once per frame
    void Start()
    {
        WaterModel.SetActive(false);
    }
    
    
    
    void Update()
    {
        if (WaterModel != null)
        {
            if (RainAmount == 0)
            {
                WaterModel.transform.localScale = new Vector3(1f,1f,0f);
            }
            else if (RainAmount > 0 && RainAmount < 20)
            {
                WaterModel.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else if (RainAmount > 20 && RainAmount < 40)
            {
                WaterModel.transform.localScale = new Vector3(1f, 1f, 2f);
            }
            else if (RainAmount > 40 && RainAmount < 60)
            {
                WaterModel.transform.localScale = new Vector3(1f, 1f, 3f);
            }
            else if (RainAmount > 60 && RainAmount < 80)
            {
                WaterModel.transform.localScale = new Vector3(1f, 1f, 5f);
            }
            else if (RainAmount > 80)
            {
                WaterModel.transform.localScale = new Vector3(1f, 1f, 8f);
            }
            //測試發現中央氣象局回傳的雨量是負值?
            else if (RainAmount <0)
            {
                WaterModel.transform.localScale = new Vector3(1f, 1f, 8f);
            }
        }
    }
}
