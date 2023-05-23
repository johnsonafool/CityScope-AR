using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    public CWBWebRequest cwbWebrequest;
    public DataSever dataSever;
    public Text DebugRegion;

    void Update()
    {

            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit Hit;
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.transform.name)
                {
                    case "新北":
                        dataSever.locationIndex = 0;                     
                        break;
                    case "臺北":
                        dataSever.locationIndex = 1;
                        break;
                    case "武陵":
                        dataSever.locationIndex = 2;
                        break;
                    case "臺中":
                        dataSever.locationIndex = 3;
                        break;
                    case "臺南":
                        dataSever.locationIndex = 4;
                        break;
                    case "高雄":
                        dataSever.locationIndex = 5;
                        break;
                    default:
                        dataSever.locationIndex = 0;
                        Debug.Log("其他縣市");
                        break;
                }
                
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                //if (Input.GetMouseButtonDown(0))
                {
                    switch(dataSever.catalogValue)
                    {
                        case "huv":
                            dataSever.HuvInfo(hit.collider.name);
                            break;
                        case "temp":
                            dataSever.TempInfo(hit.collider.name);
                            break;
                        case "rain":
                            dataSever.RainInfo(hit.collider.name);
                            break;
                        case "pm25":
                            dataSever.Pm25Info(hit.collider.name);
                            break;
                        case "weather":
                            dataSever.WeatherInfo(hit.collider.name);
                            break;
                    }
                    //Debug.Log(hit.transform.name);
                    
                }

                DebugRegion.text = hit.transform.name.ToString();

            }
        }
        
    }