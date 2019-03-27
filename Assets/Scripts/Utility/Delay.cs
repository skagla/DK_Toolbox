using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Delay : MonoBehaviour
{
    public float delay;

    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }
    public FloatEvent target;

    public List<Value> values = new List<Value>();

    private void Update()
    {
        //check for delay and send value
        for (int i = values.Count - 1; i >= 0; i--)
        {
            Value value = values[i];
            if(value.timeStamp + delay <= Time.time)
            {
                Stream(value.value);
                values.Remove(value);
            }
          

        }
    }

    public void Input(float value)
    {
        values.Add(new Value(value, Time.time));
    }

    void Stream(float value)
    {
        target.Invoke(value);
    }
}

public class Value
{
    public float value;
    public float timeStamp;
    
    public Value(float value, float timeStamp)
    {
        this.value = value;
        this.timeStamp = timeStamp;
    }
}
