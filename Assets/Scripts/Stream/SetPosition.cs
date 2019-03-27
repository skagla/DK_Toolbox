using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{


    public void SetPositionX(float x)
    {
        Vector3 position = transform.position;

        position.x = x;

        transform.position = position;
    }

    public void SetPositionY(float y)
    {
        Vector3 position = transform.position;

        position.y = y;

        transform.position = position;
    }

    public void SetPositionZ(float z)
    {
        Vector3 position = transform.position;

        position.z = z;

        transform.position = position;
    }

}
