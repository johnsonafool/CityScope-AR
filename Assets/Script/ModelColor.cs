using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelColor : MonoBehaviour
{
    
    public Color color1 = new Color(0f, 0f, 1f, 1f); // 設置第一個顏色
    public Color color2 = new Color(1f, 0f, 0f, 1f); // 設置第二個顏色

    private Renderer _renderer; // 渲染器

    public float tempmin = 20f; // 最小值
    public float tempmax = 32f; // 最大值



    void Start()
    {
        _renderer = GetComponent<Renderer>();

    }
    private void Update()
    {
        CityTemp TempScript = GetComponent<CityTemp>();
        float myVariableValue = TempScript.CountyTemp;
        float t = Mathf.InverseLerp(tempmin, tempmax, myVariableValue); // 計算變數值在最小值和最大值之間的比例
        Color color = Color.Lerp(color1, color2, t); // 根據比例在藍色和紅色之間插值計算顏色
        _renderer.material.color = color;

    }
}

