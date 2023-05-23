using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Manager : MonoBehaviour
{
    public TMP_Text locationName,date;

    public GameObject[] pins;
    public Animator infoPanel;
    bool isHiding = true;

    private void Update()
    {
        date.text = DateTime.Now.ToString();
    }

    public void setLocationName(string _locationName)
    {
        locationName.text = _locationName;
    }

    public void enabledPinAnimation(int index)
    {
        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].transform.GetChild(0).gameObject.SetActive(false);
            pins[i].transform.GetChild(0).gameObject.GetComponent<Animator>().Play("hidePin");
        }
        pins[index].transform.GetChild(0).gameObject.SetActive(true);
        pins[index].transform.GetChild(0).gameObject.GetComponent<Animator>().Play("showPin");
        locationName.text = pins[index].name;
    }

    public void enabledHideInfoPanel()
    {
        if(isHiding)
        {
            infoPanel.Play("hideInfoPanel");
        }
        else
        {
            infoPanel.Play("showInfoPanel");
        }
        isHiding = !isHiding;
    }
}
