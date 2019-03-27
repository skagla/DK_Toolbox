using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class OscReceiverStream : MonoBehaviour
{
    public OSC osc;
    public string oscAdress;
    [Slider(0, 10)]
    public int parameter;

    public float inputValue;
    private float oldTestInput;

    [BoxGroup("Mapping")]
    public bool mapping = false;
    [ReadOnly, BoxGroup("Mapping"), ShowIf("mapping")]
    public float mappedInputValue;


    [BoxGroup("Mapping"), ShowIf("mapping")]
    public float inputMin = 0;
    [BoxGroup("Mapping"), ShowIf("mapping")]
    public float inputMax = 1;
    [BoxGroup("Mapping"), ShowIf("mapping")]
    public float outputMin = 0;
    [BoxGroup("Mapping"), ShowIf("mapping")]
    public float outputMax = 1;

    [BoxGroup("Delay")]
    public bool delay = false;
    [BoxGroup("Delay"), ShowIf("delay")]
    private List<Value> values = new List<Value>();
    [BoxGroup("Delay"), ShowIf("delay")]
    public float delayInSeconds;

    [BoxGroup("Smooth")]
    public bool smooth = false;
    [BoxGroup("Smooth"), ShowIf("smooth")]
    public float smoothFactor;

    private float delayedInputValue;
    private float outputValue;
    private float oldOutputValue;
    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }
    public FloatEvent floatEvent;



    // Start is called before the first frame update
    void Start()
    {
        if (osc == null)
            osc = GameObject.Find("OSCHandler").GetComponent<OSC>();
        osc.SetAddressHandler(oscAdress, OnReceive);


    }

    // Update is called once per frame
    void Update()
    {
        if (inputValue != oldTestInput)
        {
            oldTestInput = inputValue;
            if (delay)
            {
                values.Add(new Value(inputValue, Time.time));
            }
            else
                Stream();
        }
        if (delay)
            DelayTick();
    }

    void OnReceive(OscMessage message)
    {

        inputValue = message.GetFloat(parameter);
        if (delay)
        {
            values.Add(new Value(inputValue, Time.time));
        }
        else
        {
            Stream();
        }
    }

    private void Stream()
    {
        oldOutputValue = outputValue;
        outputValue = inputValue;

        if (delay)
            outputValue = delayedInputValue;

        outputValue = Map(outputValue);

        if (smooth) {
            outputValue = Mathf.Lerp(oldOutputValue, outputValue, smoothFactor);
         }
        floatEvent.Invoke(outputValue);
    }

    public float Map(float value)
    {
        if (mapping)
            return outputMin + (outputMax - outputMin) * ((value - inputMin) / (inputMax - inputMin));
        else
            return value;
    }
  

    private void DelayTick()
    {
        for (int i = values.Count - 1; i >= 0; i--)
        {
            Value value = values[i];
            if (value.timeStamp + delayInSeconds <= Time.time)
            {

                delayedInputValue = value.value;
                Stream();
                values.Remove(value);
            }
        }
    }

}


