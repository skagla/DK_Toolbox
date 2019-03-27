using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OscReceiverSwitch : MonoBehaviour
{
    public OSC osc;
    public string oscAdress;
    public int parameter;

    public float inputValue;
    private float oldInput;
    public bool triggerd = false;
    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }
    public FloatEvent onEvent;
    public FloatEvent offEvent;

   

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
        if (inputValue != oldInput)
        {
            oldInput = inputValue;
            Trig();
        }
    }

    void OnReceive(OscMessage message)
    {
        inputValue = message.GetFloat(parameter);
        Trig();
    }

    private void Trig()
    {
        if (!triggerd && inputValue == 1f) { 
            onEvent.Invoke(inputValue);
            triggerd = true;
        }

        if (triggerd && inputValue == 0f) { 
            offEvent.Invoke(inputValue);
            triggerd = false;
        }


    }
}
