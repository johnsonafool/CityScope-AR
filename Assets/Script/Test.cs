using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float Latitude, Longitude, Altitude, X, Y, Z;
    TestSub sub = new TestSub();
    public GameObject parentobj;
    public GameObject childobj;

    void Start()
    {
        GameObject generatedObject = Instantiate(childobj, parentobj.transform);

        sub.CCC(ref Latitude, ref Longitude, ref Altitude, ref X, ref Y, ref Z);

        Debug.Log(Latitude + "; " + Longitude + "; " + Altitude + "; " + X + "; " + Y + "; " + Z);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
