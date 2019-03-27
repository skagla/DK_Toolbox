using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class OscReceiverStream : MonoBehaviour
{
    public OSC osc;
    public string oscAdress;
    [Slider(0,10)]
    public int parameter;

    public float inputValue;
    private float oldTestInput;
    [ReadOnly]
    public float mappedInputValue;

    [BoxGroup("Mapping")]
    public float inputMin = 0;
    [BoxGroup("Mapping")]
    public float inputMax = 1;
    [BoxGroup("Mapping")]
    public float outputMin = 0;
    [BoxGroup("Mapping")]
    public float outputMax = 1;

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
        if(inputValue != oldTestInput)
        {
            oldTestInput = inputValue;
            mappedInputValue = Map(inputValue);
            Stream();
        }
    }

    void OnReceive(OscMessage message)
    {
        
        inputValue = message.GetFloat(parameter);
        mappedInputValue = Map(inputValue);
        Stream();
        
    }

    private void Stream()
    {
        floatEvent.Invoke(mappedInputValue);
    }

    public float Map(float value)
    {
        return outputMin + (outputMax - outputMin) * ((value - inputMin) / (inputMax - inputMin));
    }

}
