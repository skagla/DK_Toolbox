using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSpawnDespawn : MonoBehaviour
{
    public GameObject objectToSpawn;

    List<GameObject> spawnedObjects = new List<GameObject>();

    public void TriggerSpawn()
    {
        if (objectToSpawn != null)
        {
            GameObject spawnedObject;
            spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
            spawnedObjects.Add(spawnedObject);
        }
    }

    public void TrigDespawn()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            GameObject spawnedObject = spawnedObjects[i];
            Destroy(spawnedObject);
        }
    }
}
