using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Remap : MonoBehaviour
{
    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }

    public float inputMin = 0;
    public float inputMax = 1;
    public float outputMin;
    public float outputMax;

    public float mappedValue;

    public FloatEvent target;

   

  /*  public float Map(float value)
    {
        return outputMin + (outputMax - outputMin) * ((value - inputMin) / (inputMax - inputMin));
    }
    */
    public void Map(float value)
    {
        mappedValue = outputMin + (outputMax - outputMin) * ((value - inputMin) / (inputMax - inputMin));

        target.Invoke(mappedValue);
    }

}
