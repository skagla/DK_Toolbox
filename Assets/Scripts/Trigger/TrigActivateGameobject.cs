using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigActivateGameobject : MonoBehaviour
{
    public GameObject objectToActivate;

    public void TriggerActivateGameobject()
    {
    objectToActivate.SetActive(true);
    }
}
