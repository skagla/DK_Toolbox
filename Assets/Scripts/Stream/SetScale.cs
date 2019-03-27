using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScale : MonoBehaviour
{
    public void SetScaleX(float x)
    {
        Vector3 scale = transform.localScale;

        scale.x = x;

        transform.localScale = scale;
    }
    public void SetScaleY(float y)
    {
        Vector3 scale = transform.localScale;

        scale.y = y;

        transform.localScale = scale;
    }
    public void SetScaleZ(float z)
    {
        Vector3 scale = transform.localScale;

        scale.z = z;

        transform.localScale = scale;
    }
    public void SetUniformScale(float s)
    {
        Vector3 scale = new Vector3(s, s, s);

        transform.localScale = scale;
    }
}
