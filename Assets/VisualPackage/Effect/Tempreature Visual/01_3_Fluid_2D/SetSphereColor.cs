using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SetSphereColor : MonoBehaviour
{
    public static Color color;
    public static Color target;

    public Material sphereMat;
    public Material planeMat;
   
    static float timeSpeed;

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (sphereMat != null) sphereMat.SetColor("_Color", setHotTemp());
            if (planeMat != null) planeMat.SetColor("_Color", setHotTemp());
        }
        if (Input.GetMouseButton(1))
        {
            if (sphereMat != null) sphereMat.SetColor("_Color", setColdTemp());
            if (planeMat != null) planeMat.SetColor("_Color", setColdTemp());
        }
        //Rainbow color
        
        /*color = Color.HSVToRGB( 0.5f*(Mathf.Sin( Time.time * Time.fixedDeltaTime * timeSpeed )+1f) , 1f, 1f);

        if (sphereMat != null) sphereMat.SetColor("_Color", color);
        if (planeMat != null) planeMat.SetColor("_Color", color);
        */
        //color = new Vector4( 0.5f*(Mathf.Sin( Time.time * Time.fixedDeltaTime * timeSpeed )+1f) , 1f, 1f);
    }

    public static Color setHotTemp()
    {
        color = new Vector4(0.5f * (Mathf.Sin(Time.time * Time.fixedDeltaTime * timeSpeed) + 1f), 0.5f, 1f);
        return color;
    }

    public static Color setColdTemp()
    {
        color = new Vector4(0.5f, 1f, 0.5f * (Mathf.Sin(Time.time * Time.fixedDeltaTime * timeSpeed) + 1f));
        return color;
    }
}
