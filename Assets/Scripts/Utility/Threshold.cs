using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Threshold : MonoBehaviour
{
    public float threshold;

    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }
    public FloatEvent onEvent;
    public FloatEvent offEvent;

    public void RunThreshold(float value)
    {
        if (value >= threshold)
        {
            onEvent.Invoke(1);
        }
        else
        {
            offEvent.Invoke(1);
        }

    }
}
