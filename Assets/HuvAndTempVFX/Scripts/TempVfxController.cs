using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class TempVfxController : MonoBehaviour
{
    CWBWebRequest _CWBWebRequest;
    public float values;//需改成後台收到temp data

    [SerializeField]
    private VisualEffect visualEffect;
    [SerializeField]
    public float[] periods;
    [SerializeField]
    private Gradient[] gradients;

    void Update()
    {
        if (visualEffect != null)
        {
            values = _CWBWebRequest.tempValue;

            switch (values)
            {
                case > 40: //氣溫40度
                    visualEffect.SetFloat("Period", periods[0]);
                    visualEffect.SetGradient("Color", gradients[0]);
                    break;
                case > 37 and <= 40: //氣溫37~40度
                    visualEffect.SetFloat("Period", periods[1]);
                    visualEffect.SetGradient("Color", gradients[1]);
                    break;
                case > 34 and <= 37:
                    visualEffect.SetFloat("Period", periods[2]);
                    visualEffect.SetGradient("Color", gradients[2]);
                    break;
                case > 31 and <= 34:
                    visualEffect.SetFloat("Period", periods[3]);
                    visualEffect.SetGradient("Color", gradients[3]);
                    break;
                case > 28 and <= 31:
                    visualEffect.SetFloat("Period", periods[4]);
                    visualEffect.SetGradient("Color", gradients[4]);
                    break;
                case > 25 and <= 28:
                    visualEffect.SetFloat("Period", periods[5]);
                    visualEffect.SetGradient("Color", gradients[5]);
                    break;
                case > 22 and <= 25:
                    visualEffect.SetFloat("Period", periods[6]);
                    visualEffect.SetGradient("Color", gradients[6]);
                    break;
                case > 19 and <= 22:
                    visualEffect.SetFloat("Period", periods[7]);
                    visualEffect.SetGradient("Color", gradients[7]);
                    break;
                case > 16 and <= 19:
                    visualEffect.SetFloat("Period", periods[8]);
                    visualEffect.SetGradient("Color", gradients[8]);
                    break;
                case > 13 and <= 16:
                    visualEffect.SetFloat("Period", periods[9]);
                    visualEffect.SetGradient("Color", gradients[9]);
                    break;
                case > 10 and <= 13:
                    visualEffect.SetFloat("Period", periods[10]);
                    visualEffect.SetGradient("Color", gradients[10]);
                    break;
                case > 7 and <= 10:
                    visualEffect.SetFloat("Period", periods[11]);
                    visualEffect.SetGradient("Color", gradients[11]);
                    break;
                case > 4 and <= 7:
                    visualEffect.SetFloat("Period", periods[12]);
                    visualEffect.SetGradient("Color", gradients[12]);
                    break;
                case > 1 and <= 4:
                    visualEffect.SetFloat("Period", periods[13]);
                    visualEffect.SetGradient("Color", gradients[13]);
                    break;
                case <= 1:
                    visualEffect.SetFloat("Period", periods[14]);
                    visualEffect.SetGradient("Color", gradients[14]);
                    break;
                default: //預設OR其他溫度
                    visualEffect.SetFloat("Period", periods[15]);
                    visualEffect.SetGradient("Color", gradients[15]);
                    break;
            }
        }

    }
}