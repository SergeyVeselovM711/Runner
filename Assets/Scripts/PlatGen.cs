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

    // Start is called before the first frame update
    void Start()
    {
        //platWidth = platform.GetComponent<BoxCollider2D>().size.x;

        platsWidth = new float[platformsM.Length];

        for ( int i = 0; i < platformsM.Length; i++ )
        {
            platsWidth[i] = platformsM[i].platform.GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < genPoint.position.x) //расстояние для появления платформ
        {
            distBetween = Random.Range(distMin, distMax);

            platSelector = Random.Range(0, platformsM.Length); //случайные платформы

            transform.position = new Vector3(transform.position.x + platsWidth[platSelector] + distBetween, transform.position.y, transform.position.z);

            

            //Instantiate(/*platform*/ platforms[platSelector], transform.position, transform.rotation);

            GameObject newPlatform = platformsM[platSelector].GetPlat();

            newPlatform.transform.position = transform.position; //установка новой платформы
            newPlatform.transform.rotation = transform.rotation; //вращение новой платформы
            newPlatform.SetActive(true); //активация платформ
        }
    }
}
