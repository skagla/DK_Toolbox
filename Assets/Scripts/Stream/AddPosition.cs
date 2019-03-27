using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPosition : MonoBehaviour
{


    public void AddPositionX(float x)
    {
        Vector3 position = transform.position;

        position.x += x;

        transform.position = position;
    }

    public void AddPositionY(float y)
    {
        Vector3 position = transform.position;

        position.y += y;

        transform.position = position;
    }

    public void AddPositionZ(float z)
    {
        Vector3 position = transform.position;

        position.z += z;

        transform.position = position;
    }

}
