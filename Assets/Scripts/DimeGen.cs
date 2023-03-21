using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimeGen : MonoBehaviour
{

    public ObjectPooler dimePool;

    public float distBetweenDimes;


    public void SpawnDime(Vector3 startPosition)
    {
        GameObject dime1 = dimePool.GetPooledObject();
        dime1.transform.position = startPosition;
        dime1.SetActive(true);

        GameObject dime2 = dimePool.GetPooledObject();
        dime2.transform.position = new Vector3(startPosition.x - distBetweenDimes, startPosition.y, startPosition.z);
        dime2.SetActive(true);

        GameObject dime3 = dimePool.GetPooledObject();
        dime3.transform.position = new Vector3(startPosition.x + distBetweenDimes, startPosition.y, startPosition.z);
        dime3.SetActive(true);

    }

}
