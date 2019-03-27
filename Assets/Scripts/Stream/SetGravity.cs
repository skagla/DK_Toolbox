using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGravity : MonoBehaviour
{
    public void SetGravityX(float x)
    {
        Vector3 gravity = Physics.gravity;

        gravity.x = x;

        Physics.gravity = gravity;
    }

    public void SetGravityY(float y)
    {
        Vector3 gravity = Physics.gravity;

        gravity.y = y;

        Physics.gravity = gravity;
    }

    public void SetGravityZ(float z)
    {
        Vector3 gravity = Physics.gravity;

        gravity.z = z;

        Physics.gravity = gravity;
    }

}
