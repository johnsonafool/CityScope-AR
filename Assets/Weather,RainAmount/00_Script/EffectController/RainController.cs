using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class RainController : MonoBehaviour
{
    [SerializeField]
    private VisualEffect RainVFX;

    [SerializeField, Range(0f, 2000f)]
    private float RainRate;
    public float RainAmount;

    void Update()
    {

        if(RainVFX != null)
        {
            RainVFX.SetFloat("Rain Rate", RainRate);
            
            if(RainAmount == 0)
            {
                Debug.Log("No fucking Rain");
                RainRate= 0f;
            }
            else if(RainAmount >0 && RainAmount <20)
            {
                RainRate= 200f;
            }
            else if (RainAmount > 20 && RainAmount < 40)
            {
                RainRate = 400f;
            }
            else if (RainAmount > 40 && RainAmount < 60)
            {
                RainRate = 800f;
            }
            else if (RainAmount > 60 && RainAmount < 80)
            {
                RainRate = 1400f;
            }
            else if (RainAmount > 80)
            {
                RainRate = 2000f;
            }
            //���յo�{������H���^�Ǫ��B�q�O�t��?
            else if (RainAmount <0)
            {
                RainRate = 2000;
            }
        }
    }
}
