using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColission : MonoBehaviour
{

    public OSC osc;

    // Start is called before the first frame update
    void Start()
    {
        if (osc == null)
            osc = GameObject.Find("OSCHandler").GetComponent<OSC>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        /*  if ((collision.relativeVelocity.magnitude > 0.65f) && (nextEvent < Time.time))
          { //threshold !!!!
              nextEvent = Time.time + timeBetween;
          }
          */

        OscMessage message = new OscMessage();

        message.address = "/colission";
        message.values.Add(collision.relativeVelocity.magnitude);
        osc.Send(message);
    }
}
