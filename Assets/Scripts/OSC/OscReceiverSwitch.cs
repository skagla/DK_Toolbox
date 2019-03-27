using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class OscReceiverSwitch : MonoBehaviour
{
    public OSC osc;
    public string oscAdress;
    [Slider(0, 10)]
    public int parameter;

    public float inputValue;
    [ReadOnly]
    public float mappedInputValue;
    private float oldInput;

    /* [BoxGroup("Mapping")]
     public float inputMin = 0;
     [BoxGroup("Mapping")]
     public float inputMax = 1;
     [BoxGroup("Mapping")]
     public float outputMin = 0;
     [BoxGroup("Mapping")]
     public float outputMax = 1;
 */
    public bool reverseInput;
    public bool triggerAtPlay = false;
    [ReadOnly]
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

        if (triggerAtPlay)
        {
            if (reverseInput)
            {
                inputValue = 0;
                mappedInputValue = 1;
                Trig();

            }
            else
            {
                inputValue = 1;
                mappedInputValue = 0;
                Trig();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inputValue != oldInput)
        {
            oldInput = inputValue;
            mappedInputValue = ReverseInput(inputValue);

            Trig();
        }
    }

    void OnReceive(OscMessage message)
    {
        inputValue = message.GetFloat(parameter);
        mappedInputValue = ReverseInput(inputValue);
        Trig();
    }

    private void Trig()
    {
        if (!triggerd && mappedInputValue == 1f)
        {
            onEvent.Invoke(1);
            triggerd = true;
        }

        if (triggerd && mappedInputValue == 0f)
        {
            offEvent.Invoke(0);
            triggerd = false;
        }
    }

  /*  public float Map(float value)
    {
        return outputMin + (outputMax - outputMin) * ((value - inputMin) / (inputMax - inputMin));
    }
    */
    float ReverseInput(float input)
    {
        if (reverseInput)
        {
            if (input == 0)
                return 1;

            if (input == 1)
                return 0;

            return -1;
        }
        else
        {
            return input;
        }
    }
}
