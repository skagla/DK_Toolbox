using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRotation : MonoBehaviour
{
    public void SetRotationX(float x)
    {
        Quaternion rotation = transform.rotation;
        rotation = Quaternion.Euler(new Vector3(x, rotation.eulerAngles.y, rotation.eulerAngles.z));
        transform.rotation = rotation;
    }

    public void SetRotationY(float y)
    {
        Quaternion rotation = transform.rotation;
        rotation = Quaternion.Euler(new Vector3(rotation.eulerAngles.x, y, rotation.eulerAngles.z));
        transform.rotation = rotation;
    }

    public void SetRotationZ(float z)
    {
        Quaternion rotation = transform.rotation;
        rotation = Quaternion.Euler(new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y, z));
        transform.rotation = rotation;
    }
}
