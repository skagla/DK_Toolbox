using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigDeactivateGameobject : MonoBehaviour
{
    public GameObject objectToDeactivate;

    public void TriggerDeactivateGameobject()
    {
        objectToDeactivate.SetActive(false);
    }
}
