using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnableObject : MonoBehaviour
{
    public GameObject Object1, Object2;

    public void whenButtonClicked()
    {
        if (Object1.activeInHierarchy == true || Object2.activeInHierarchy == true)
        {
            Object1.SetActive(false);
            Object2.SetActive(false);
        }
        else
        {
            Object1.SetActive(true);
            Object2.SetActive(true);
        }
    }
}
