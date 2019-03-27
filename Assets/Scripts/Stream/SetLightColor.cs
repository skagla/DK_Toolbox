using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLightColor : MonoBehaviour
{
    public Light light;

    void Setup()
    {
        light = GetComponent<Light>();
    }

    public void SetLightColorR(float r)
    {
        Color lightColor = light.color;
        lightColor.r = r;
        light.color = lightColor;
    }

    public void SetLightColorG(float g)
    {
        Color lightColor = light.color;
        lightColor.g = g;
        light.color = lightColor;
    }

    public void SetLightColorB(float b)
    {
        Color lightColor = light.color;
        lightColor.b = b;
        light.color = lightColor;
    }

    public void SetLightColorAlpha(float a)
    {
        Color lightColor = light.color;
        lightColor.a = a;
        light.color = lightColor;
    }

}
