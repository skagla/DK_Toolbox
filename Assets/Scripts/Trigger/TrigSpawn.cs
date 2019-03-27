using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigSpawn : MonoBehaviour
{
    public bool trig = false;
    public GameObject objectToSpawn;
    public float lifeTime;

    List<GameObject> spawnedObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trig)
        {
            trig = false;
            TriggerSpawn();
        }

        //check lifetime and in case destroy object
        if (lifeTime > 0)
        {
            //go backwards through the list, so we can delete objects
            for (int i = spawnedObjects.Count -1; i >= 0; i--)
            {
                GameObject spawnedObject = spawnedObjects[i];

                if (spawnedObject.GetComponent<Stats>().creationTime + lifeTime < Time.time)
                {
                    spawnedObjects.RemoveAt(i);
                    Destroy(spawnedObject);
                }
            }
        }
    }

    public void TriggerSpawn()
    {
        if (objectToSpawn != null)
        {
            GameObject spawnedObject;
            spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
            spawnedObjects.Add(spawnedObject);
            spawnedObject.AddComponent<Stats>().creationTime = Time.time;

        }
    }
}
