using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterialColor : MonoBehaviour
{
    public  Renderer render;

    void Setup()
    {
        render = GetComponent<Renderer>();
    }

    public void SetMaterialColorR(float r)
    {
        Color materialColor = render.material.color;
        materialColor.r = r;
        render.material.color = materialColor;
    }

    public void SetMaterialColorG(float g)
    {
        Color materialColor = render.material.color;
        materialColor.g = g;
        render.material.color = materialColor;
    }

    public void SetMaterialColorB(float b)
    {
        render.material.shader = Shader.Find("_Color");
        render.material.SetColor("_Color", Color.green);
    }

    public void SetMaterialColorAlpha(float a)
    {
        Color materialColor = render.material.color;
        materialColor.a = a;
        render.material.color = materialColor;
    }



}
