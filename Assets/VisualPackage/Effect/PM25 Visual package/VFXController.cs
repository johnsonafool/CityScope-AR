using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class VFXController : MonoBehaviour
{
    [SerializeField]
    private VisualEffect visualEffect;

    [SerializeField, Range(0, 10)]
    private float frequency = 0;

    [SerializeField, Range(0, 25000)]
    public float maxParticles = 25000f;

    [SerializeField]
    private Gradient gradientGreen, gradientYellow, gradientOrange, gradientRed, gradientPurple, gradientBlackRed;

    void Update()
    {
        if (visualEffect != null)
        {
            visualEffect.SetFloat("Frequency", frequency);
            visualEffect.SetFloat("Max Particles", maxParticles);

            if (maxParticles < 1000)
            {
                visualEffect.SetGradient("Gradient", gradientGreen);
            }
            else if (maxParticles > 1000 && maxParticles < 3000)
            {
                visualEffect.SetGradient("Gradient", gradientYellow);
            }
            else if (maxParticles > 3000 && maxParticles < 5000)
            {
                visualEffect.SetGradient("Gradient", gradientOrange);
            }
            else if (maxParticles > 5000 && maxParticles < 7000)
            {
                visualEffect.SetGradient("Gradient", gradientRed);
            }
            else if (maxParticles > 7000 && maxParticles < 15000)
            {
                visualEffect.SetGradient("Gradient", gradientPurple);
            }
            else if (maxParticles > 15000 && maxParticles < 25000)
            {
                visualEffect.SetGradient("Gradient", gradientBlackRed);
            }
        }
    }
}
