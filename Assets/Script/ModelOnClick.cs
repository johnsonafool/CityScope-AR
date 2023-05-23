using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelOnClick : MonoBehaviour
{
    public GameObject ModelToChange;
    private MeshRenderer meshRenderer;

    private int min;              //ノ砞﹚计璸だ牧
    private int sec;              //ノ砞﹚计璸计
    public int timer;            //计璸竒传衡羆计
    private float TempNumber;             //放

    public Text timertext;         //砞﹚礶计璸ゅ
    public Text nametoshow;



    void Start()
    {
        meshRenderer = ModelToChange.GetComponent<MeshRenderer>();

    }

    private void Update()
    {
        CityTemp TempScript = GetComponent<CityTemp>();
        TempNumber = TempScript.CountyTemp;
    }

    private void OnMouseDown()
    {
        Debug.Log("Click!");
        sec = 2;
        StartCoroutine(StartCountdown());
    }


    IEnumerator StartCountdown()
    {
        meshRenderer.material.color = Color.red;

        timertext.text = string.Format("{0}:{1}", min.ToString("00"), sec.ToString("00"));
        nametoshow.text = string.Format("{0}瞷放:{1}", ModelToChange.name.ToString(), TempNumber.ToString("00.0"));


        timer = (min * 60) + sec;       //盢丁传衡计

        while (timer > 0)                   //狦丁﹟ゼ挡
        {
            yield return new WaitForSecondsRealtime(1); //单Ω磅︽

            timer--;                        //羆计搭 1
            sec--;                            //盢计搭 1

            if (sec < 0 && min > 0)         //狦计 0 だ牧 0
            {
                min --;                     //盢だ牧搭 1
                sec = 59;                     //盢计砞 59
            }
            else if (sec < 0 && min == 0)   //狦计 0 だ牧 0
            {
                sec = 0;                      //砞﹚计单 0
            }
            timertext.text = string.Format("{0}:{1}", min.ToString("00"), sec.ToString("00"));
        }

        yield return new WaitForSecondsRealtime(1);   //丁挡陪ボ 00:00 氨痙

        nametoshow.text = string.Empty;
        meshRenderer.material.color = Color.yellow;
        sec = 2;
    }
}