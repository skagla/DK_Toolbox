using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OscReceiverStream : MonoBehaviour
{
    public OSC osc;
    public string oscAdress;
    public int parameter;

    public float inputValue;
    private float oldTestInput;

    public float inputMin = 0;
    public float inputMax = 1;
    public float outputMin = 0;
    public float outputMax = 1;

    [System.Serializable]
    public class ColorEvent : UnityEvent<float> { }
    public ColorEvent target;



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
            Stream();
        }
    }

    void OnReceive(OscMessage message)
    {
        
        inputValue = message.GetFloat(parameter);
        Stream();
        
    }

    private void Stream()
    {
        target.Invoke(Map(inputValue));
    }

    public float Map(float value)
    {
        return outputMin + (outputMax - outputMin) * ((value - inputMin) / (inputMax - inputMin));
    }

}
