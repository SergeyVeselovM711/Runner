using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatGen : MonoBehaviour
{
    public GameObject platform;
    public Transform genPoint;
    public float distBetween;

    float platWidth;

    public float distMin;
    public float distMax;

    //public GameObject[] platforms;

    int platSelector;
    float[] platsWidth;

    public PlatManager[] platformsM;

    float minHeight;
    public Transform maxHeightPoint;
    float maxHeight;
    public float maxHeightChange;
    float heightChange;

    private DimeGen theDimeGen;
    public float randomDimeTheshold;

    public float randomBallTheshold;
    public ObjectPooler ballPool;

    // Start is called before the first frame update
    void Start()
    {
        //platWidth = platform.GetComponent<BoxCollider2D>().size.x;

        platsWidth = new float[platformsM.Length];

        for ( int i = 0; i < platformsM.Length; i++ )
        {
            platsWidth[i] = platformsM[i].platform.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        theDimeGen = FindObjectOfType<DimeGen>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < genPoint.position.x) //расстояние для появления платформ
        {
            distBetween = Random.Range(distMin, distMax);

            platSelector = Random.Range(0, platformsM.Length); //случайные платформы

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange); //случайная высота платформ

            if (heightChange > maxHeight) //ограничение
            {
                heightChange = maxHeight;
            }

            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platsWidth[platSelector])/2 + distBetween, heightChange, transform.position.z);

            

            //Instantiate(/*platform*/ platforms[platSelector], transform.position, transform.rotation);

            GameObject newPlatform = platformsM[platSelector].GetPlat();

            newPlatform.transform.position = transform.position; //установка новой платформы
            newPlatform.transform.rotation = transform.rotation; //вращение новой платформы
            newPlatform.SetActive(true); //активация платформ


            if (Random.Range(0f, 100f) < randomDimeTheshold)
            {
                theDimeGen.SpawnDime(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            if (Random.Range(0f, 100f) < randomBallTheshold)
            {
                GameObject newBall = ballPool.GetPooledObject();

                Vector3 ballPosition = new Vector3(0f, 0.5f, 0f);

                newBall.transform.position = transform.position + ballPosition;
                newBall.transform.rotation = transform.rotation;
                newBall.SetActive(true);

                //theDimeGen.SpawnDime(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }


            transform.position = new Vector3(transform.position.x + (platsWidth[platSelector]) / 2, transform.position.y, transform.position.z);

        }
    }
}
