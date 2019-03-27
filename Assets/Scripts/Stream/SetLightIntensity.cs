using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLightIntensity : MonoBehaviour
{
    public Light light;

    void Setup()
    {
        light = GetComponent<Light>();
    }

    public void SetLightintensity(float intensity)
    {
        light.intensity = intensity;
    }

}
