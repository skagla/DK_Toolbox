using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject lookAtTarget;

    void Update()
    {
        if (lookAtTarget != null)
            transform.LookAt(lookAtTarget.transform.position); 
    }
}
